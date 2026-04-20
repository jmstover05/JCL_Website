using Microsoft.EntityFrameworkCore;

namespace JCL_Website.Models
{
    public class EfOrderRepository: OrderRepository
    {
        private ApplicationDbContext context;
        public EfOrderRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Order> Orders => context.Orders
        .Include(o => o.Lines)
        .ThenInclude(l => l.Product);
        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(l => l.Product));
            if (order.OrderID == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}
