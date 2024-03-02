namespace Teknoroma.Application.Features.Products.Queries.GetProductSupplyReport
{
    public class GetProductSupplyReportQueryResponse
    {
		public Guid ProductId { get; set; }
		public string ProductName { get; set; }
        public int TotalSupply { get; set; }
    }
}
