namespace JCL_Website.Models
{
    public interface OrderRepository
    {
        IEnumerable<Order> Orders { get; }
        void SaveOrder(Order order);
    }
}
