namespace JCL_Website.Models
{
    public class EfProductRepository : ProductRepository
    {
        private ApplicationDbContext context;
        public EfProductRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Product> Products => context.Products;
    }
}
