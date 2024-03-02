namespace Teknoroma.Application.Features.Products.Models
{
	public class ProductEarningReportViewModel
	{
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
		public decimal TotalPrice { get; set; }
	}
}
