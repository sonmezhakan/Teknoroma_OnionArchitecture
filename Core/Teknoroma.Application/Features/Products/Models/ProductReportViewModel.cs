namespace Teknoroma.Application.Features.Products.Models
{
	public class ProductReportViewModel
	{
        public List<ProductSellingReportViewModel>  ProductSellingViewModels { get; set; }
        public List<ProductEarningReportViewModel> ProductEarningViewModels { get; set; }
        public List<ProductSupplyReportViewModel> ProductSupplyViewModels { get; set; }
    }
}
