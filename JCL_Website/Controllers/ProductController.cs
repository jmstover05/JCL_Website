using JCL_Website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;
namespace JCL_Website.Controllers
{
    //a new product controller is created every time the website is ran
    public class ProductController : Controller
    {
        private ProductRepository productRepository;
        public ProductController(ProductRepository repo)
        {
            productRepository = repo;

        }


        // vvv put a function here that brings you to the products page (returns a view) vvv
        public ViewResult Index()
        {
            return View(productRepository.Products);
        }

    }
}
