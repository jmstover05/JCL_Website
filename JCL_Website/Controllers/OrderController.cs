using JCL_Website.Models;
using Microsoft.AspNetCore.Mvc;

namespace JCL_Website.Controllers
{
    public class OrderController : Controller
    {
        private OrderRepository repository;
        private CartRepository cart;
        public OrderController(OrderRepository repoService, CartRepository cartService)
        {
            repository = repoService;
            cart = cartService;
        }
        public ViewResult Checkout() => View(new Order());
        public ViewResult Find() => View();

        [HttpPost]
        public ViewResult Retrieval(int orderID)
        {
            Order order = repository.Orders.FirstOrDefault(o => o.OrderID == orderID);
            if (order == null)
            {
                ModelState.AddModelError("", "Sorry! We cannot find an order under that orderID...");
                return View("Find");
            }
            else
            {
                return View(order);

            }
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
               
            }
            if (ModelState.IsValid)
            {
                order.Lines = cart.Lines.ToArray();
                repository.SaveOrder(order);
                cart.Clear();
                return View("Completed", order.OrderID);
            }
            else
            {
                return View(order);
            }
        }
        public ViewResult Completed(int orderID)
        {
            cart.Clear();
            return View();
        }
    }
}

