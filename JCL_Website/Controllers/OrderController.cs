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

        [HttpPost]
        public ViewResult Retrieval(int orderID)
        {
            Order order = repository.Orders.FirstOrDefault(o => o.OrderID == orderID);
            //check if order is not null pls
            return View(order);
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
                return View("Completed");
            }
            else
            {
                return View(order);
            }
        }
        public ViewResult Completed()
        {
            cart.Clear();
            return View();
        }
    }
}

