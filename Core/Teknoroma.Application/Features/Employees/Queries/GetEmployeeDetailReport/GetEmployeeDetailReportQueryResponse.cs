namespace Teknoroma.Application.Features.Employees.Queries.GetEmployeeDetailReport
{
    public class GetEmployeeDetailReportQueryResponse
    {
        public string UserName { get; set; }
        public string BranchName { get; set; }
        public string ProductName { get; set; }
        public int TotalSales { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
