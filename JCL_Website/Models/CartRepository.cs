namespace JCL_Website.Models
{
    public class CartRepository
    {
        //list of products that have been put in the user's cart.
        public List<Product> Products => new List<Product> {
            new Product { name = "Football", price = 25 },
            new Product { name = "Surf board", price = 179 },
            new Product { name = "Running shoes", price = 95 }
            };
        public float getCartSum()
        {
            float sum = 0;
            foreach(var product in Products)
            {
                sum += product.price;
            }
            return sum;
        }

      
    }
}
