namespace Teknoroma.Application.Features.Products.Queries.GetProductSellingReport
{
	public class GetProductSellingReportQueryResponse
	{
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
		public int TotalSales { get; set; }
	}
}
