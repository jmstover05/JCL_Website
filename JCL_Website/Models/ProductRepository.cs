namespace JCL_Website.Models
{
    public interface ProductRepository
    {
        IEnumerable<Product> Products { get; }
    }
}
