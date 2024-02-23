namespace Teknoroma.Application.Features.Stocks.Models
{
	public class StockListViewModel
    {
        public string? BranchName { get; set; }
        public Guid? ProductID { get; set; }
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int CriticalStock { get; set; }
        public string? ImagePath { get; set; }
    }
}
