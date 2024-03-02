namespace Teknoroma.Application.Features.Products.Queries.GetProductSalesDetailReport
{
    public class GetProductSalesDetailReportQueryResponse
    {
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        public string BranchName { get; set; }
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public string UserName { get; set; }
        public DateTime OrderDate { get; set; }

    }
}
