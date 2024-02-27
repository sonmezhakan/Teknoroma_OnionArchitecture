namespace Teknoroma.Application.Features.Stocks.Queries.GetByBranchId
{
	public class GetByBranchIdStockQueryResponse
    {
        public Guid BranchId { get; set; }
        public Guid ProductId { get; set; }
        public int UnitsInStock { get; set; }
    }
}
