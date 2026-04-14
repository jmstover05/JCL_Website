namespace JCL_Website.Models
{
    public class FakeProductRepository : ProductRepository
    {
        public IEnumerable<Product> Products => new List<Product> {
            new Product { name = "Football", price = 25 },
            new Product { name = "Surf board", price = 179 },
            new Product { name = "Running shoes", price = 95 }
            };
    }
}
