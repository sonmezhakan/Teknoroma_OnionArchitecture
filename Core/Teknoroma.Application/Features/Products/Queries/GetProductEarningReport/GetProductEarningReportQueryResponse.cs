namespace Teknoroma.Application.Features.Products.Queries.GetProductEarningReport
{
	public class GetProductEarningReportQueryResponse
	{
		public Guid ProductId { get; set; }
		public string ProductName { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
