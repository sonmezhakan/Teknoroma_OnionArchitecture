namespace Teknoroma.Application.Features.Stocks.Queries.GetList
{
    public class GetAllStockQueryResponse
    {
		public Guid ProductId { get; set; }
		public string ProductName { get; set; }
		public string BrandName { get; set; }
		public decimal UnitPrice { get; set; }
		public int UnitsInStock { get; set; }
		public int CriticalStock { get; set; }
		public string ImagePath { get; set; }
	}

}
