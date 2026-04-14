using Microsoft.AspNetCore.Mvc;
using JCL_Website.Models;
namespace JCL_Website.Controllers
{
    public class ProductController: Controller
    {
        private ProductRepository productRepository;
        public ProductController(ProductRepository repo)
        {
            productRepository = repo;
        }
        [Route("shoppingCart")]
        public ViewResult CartList() => View(productRepository.Products);

    }
}
