namespace Teknoroma.Application.Features.Categories.Models
{
    public class CategoryReportViewModel
    {
        public List<CategorySellingReportViewModel> CategorySellingReportViewModels { get; set; }
        public List<CategoryEarningReportViewModel> CategoryEarningReportViewModels { get; set; }
        public List<CategorySupplyReportViewModel> CategorySupplyReportViewModels { get; set; }
    }
}
