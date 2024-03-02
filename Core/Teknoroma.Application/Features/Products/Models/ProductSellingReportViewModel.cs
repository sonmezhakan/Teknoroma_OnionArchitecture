namespace Teknoroma.Application.Features.Products.Models
{
	public class ProductSellingReportViewModel
	{
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
		public int TotalSales { get; set; }
	}
}
