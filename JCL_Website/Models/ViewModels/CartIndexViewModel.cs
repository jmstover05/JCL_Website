
using JCL_Website.Models;

namespace JCL_Website.Models.ViewModels
{
    public class CartIndexViewModel
    {
        public CartRepository Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}
