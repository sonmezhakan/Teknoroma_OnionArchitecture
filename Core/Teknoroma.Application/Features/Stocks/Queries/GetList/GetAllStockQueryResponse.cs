namespace Teknoroma.Application.Features.Stocks.Queries.GetList
{
    public class GetAllStockQueryResponse
    {
        public string BranchName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int CriticalStock { get; set; }
        public bool IsActive { get; set; }
    }

}
