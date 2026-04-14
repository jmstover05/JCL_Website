namespace JCL_Website.Models
{
    public class Product
    {
        public int productID { get; set; }
        public string name { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public float price { get; set; }
        public string category { get; set; } = string.Empty;

    }
}
