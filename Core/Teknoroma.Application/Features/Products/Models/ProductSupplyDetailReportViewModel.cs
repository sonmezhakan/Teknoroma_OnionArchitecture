namespace Teknoroma.Application.Features.Products.Models
{
	public class ProductSupplyDetailReportViewModel
	{
		public Guid ProductId { get; set; }
		public string ProductName { get; set; }
		public string BranchName { get; set; }
		public string CategoryName { get; set; }
		public string BrandName { get; set; }
		public int Quantity { get; set; }
		public string InvoiceNumber { get; set; }
		public string CompanyName { get; set; }
		public string UserName { get; set; }
		public DateTime StockEntryDate { get; set; }
	}
}
