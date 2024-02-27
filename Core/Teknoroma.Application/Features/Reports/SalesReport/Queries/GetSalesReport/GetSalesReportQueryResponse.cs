namespace Teknoroma.Application.Features.Reports.SalesReport.Queries.GetSalesReport
{
    public class GetSalesReportQueryResponse
    {
        //Selling
        public string BestSellingProductName { get; set; }
        public int BestSellingProductQuantity { get; set; }

        public string BestSellingBranchName { get; set; }
        public int BestSellingBranchQuantity { get; set; }

        public string BestSellingCategoryName { get; set; }
        public int BestSellingCategoryQuantity { get; set; }

        public string BestSellingCustomerName { get; set; }
        public int BestSellingCustomerQuantity { get; set; }

        public string BestSellingEmployeeName { get; set; }
        public int BestSellingEmployeeQuantity { get; set; }


        //Earning
        public string BestEarningProductName { get; set; }
        public decimal BestEarningProductPrice { get; set; }

        public string BestEarningBranchName { get; set; }
        public decimal BestEarningBranchPrice { get; set; }

        public string BestEarningCategoryName { get; set; }
        public decimal BestEarningCategoryPrice { get; set; }

        public string BestEarningCustomerName { get; set; }
        public decimal BestEarningCustomerPrice { get; set; }

        public string BestEarningEmployeeName { get; set; }
        public decimal BestEarningEmployeePrice { get; set; }
    }
}
