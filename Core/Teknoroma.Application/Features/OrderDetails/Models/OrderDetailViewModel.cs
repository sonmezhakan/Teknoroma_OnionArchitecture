namespace Teknoroma.Application.Features.OrderDetails.Models
{
	public class OrderDetailViewModel
	{
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public string ImagePath { get; set; }
    }
}
