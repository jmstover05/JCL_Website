namespace JCL_Website.Models
{
    public class CartRepository
    {
        
        private List<CartLine> lineCollection = new List<CartLine>();
        public const float TAX_RATE = 0.06f;
        private float currentTaxAmnt = 0.0f;
        public virtual void AddItem(Product product, int quantity)
        {
            CartLine line = lineCollection
            .Where(p => p.Product.productID == product.productID)
            .FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public virtual void RemoveLine(Product product) =>
            lineCollection.RemoveAll(l => l.Product.productID == product.productID);
        public virtual float ComputeTotalValue()
        {
            float sum = 0.0f;
            sum += lineCollection.Sum(e => e.Product.price * e.Quantity);
            currentTaxAmnt = sum * TAX_RATE;
            sum += currentTaxAmnt;
            return sum;
        }
        public virtual float GetCurrentTaxAmnt()
        {
            return currentTaxAmnt;
        }

        
        public virtual void Clear()
        {
            currentTaxAmnt = 0.0f;
            lineCollection.Clear();
        }
        
        public virtual IEnumerable<CartLine> Lines => lineCollection;
    }
    public class CartLine
    {
        public int CartLineID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }

}

