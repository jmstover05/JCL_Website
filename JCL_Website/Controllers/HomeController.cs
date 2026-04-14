using System.Diagnostics;
using JCL_Website.Models;
using Microsoft.AspNetCore.Mvc;

namespace JCL_Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public ViewResult LoginPage()
        {
            return View("LoginPage");
        }

        [HttpGet]
        public ViewResult CreateAccountPage()
        {
            return View("CreateAccountPage");
        }

        [HttpPost]
        public ViewResult CreateAccountPage(CustomerAccount customerAccount)
        {
            return View("CreateAccountPage");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
