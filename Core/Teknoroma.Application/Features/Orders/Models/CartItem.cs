namespace Teknoroma.Application.Features.Orders.Models
{
	public class CartItem
	{
        public CartItem()
        {
            Quantity = 1;
        }
		public Guid ID { get; set; }
        public Guid BranchID { get; set; }
        public string ProductName { get; set; }
		public decimal UnitPrice { get; set; }
		public int Quantity { get; set; }
		public decimal Subtotal { get { return Quantity * UnitPrice; } }
		public string ImagePath { get; set; }
    }
}
