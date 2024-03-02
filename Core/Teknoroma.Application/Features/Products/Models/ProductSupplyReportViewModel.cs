namespace Teknoroma.Application.Features.Products.Models
{
    public class ProductSupplyReportViewModel
    {
		public Guid ProductId { get; set; }
		public string ProductName { get; set; }
        public int TotalSupply { get; set; }
    }
}
