namespace Harbor.Models
{
    public class CartItem
    {
        public Guid Id { get; set; }
        public Guid ProductID { get; set; }
        public string Product_Name { get; set; }
        public int Product_Quantity { get; set; }
        public decimal Product_Price { get; set; }

    }
}
