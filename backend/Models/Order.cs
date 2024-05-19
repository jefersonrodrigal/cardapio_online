namespace LanchoneteAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int NumberOrder { get; set; }
        public string ProductName { get; set; }
        public decimal ItemPrice { get; set; }
        public int Quantity { get; set; }
    }
}
