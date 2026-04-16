using Newtonsoft.Json;
using JCL_Website.Infrastructure;


namespace JCL_Website.Models
{
    /// <summary>
    /// The SessionCart class subclasses the CartRepository class and overrides the AddItem, RemoveLine, and Clear
    /// methods, so they call the base implementations and then store the updated state in the session using the
    /// extension methods on the ISession interface.
    /// </summary>
    public class SessionCart: CartRepository
    {
        public static CartRepository GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()
            .HttpContext?.Session;
            SessionCart cart = session?.GetJson<SessionCart>("Cart")
            ?? new SessionCart();
            cart.Session = session;
            return cart;
        }
        [JsonIgnore]
        public ISession Session { get; set; }
        public override void AddItem(Product product, int quantity)
        {
            base.AddItem(product, quantity);
            Session.SetJson("Cart", this);
        }
        public override void RemoveLine(Product product)
        {
            base.RemoveLine(product);
            Session.SetJson("Cart", this);
        }
        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}
