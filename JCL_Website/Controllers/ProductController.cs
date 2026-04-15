using Microsoft.AspNetCore.Mvc;
using JCL_Website.Models;
using System.Diagnostics;
namespace JCL_Website.Controllers
{
    //a new product controller is created every time the website is ran
    public class ProductController: Controller
    {
        private ProductRepository productRepository;
        private CartRepository cartRepository;
        public ProductController(ProductRepository repo)
        {
            productRepository = repo;
            cartRepository = new CartRepository();
        }

        // brings you to the shopping cart page, passing the cart repository's list of products
        [Route("shoppingCart")]
        public ViewResult CartList() => View(cartRepository);
        public ViewResult removeProductFromCart(Product product)
        {
            if(cartRepository.Products.Contains(product))
            {
                cartRepository.Products.Remove(product);
                Console.WriteLine("Removed the product");
            }
            else
            {
                Debug.WriteLine("didn't do it lol");
            }

                return View(cartRepository);
        }
    }
}
