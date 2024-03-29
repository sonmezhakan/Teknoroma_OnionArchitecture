﻿using MediatR;
using Teknoroma.Application.Features.Branches.Queries.GetBranchEarningReport;
using Teknoroma.Application.Features.Branches.Queries.GetBranchSellingReport;
using Teknoroma.Application.Features.Brands.Quries.GetBrandEarningReport;
using Teknoroma.Application.Features.Brands.Quries.GetBrandSellingReport;
using Teknoroma.Application.Features.Categories.Queries.GetCategoryEarningReport;
using Teknoroma.Application.Features.Categories.Queries.GetCategorySellingReport;
using Teknoroma.Application.Features.Customers.Queries.GetCustomerEarningReport;
using Teknoroma.Application.Features.Customers.Queries.GetCustomerSellingReport;
using Teknoroma.Application.Features.Employees.Queries.GetEmployeeEarningReport;
using Teknoroma.Application.Features.Employees.Queries.GetEmployeeSellingReport;
using Teknoroma.Application.Features.Products.Queries.GetProductEarningReport;
using Teknoroma.Application.Features.Products.Queries.GetProductSellingReport;

namespace Teknoroma.Application.Features.Orders.Queries.GetSalesReport
{
    public class GetSalesReportQueryHandler : IRequestHandler<GetSalesReportQueryRequest, GetSalesReportQueryResponse>
    {
        private readonly IMediator _mediator;

        public GetSalesReportQueryHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<GetSalesReportQueryResponse> Handle(GetSalesReportQueryRequest request, CancellationToken cancellationToken)
        {
            DateTime startDate = DateTime.MinValue;
            DateTime endDate = DateTime.MaxValue;
            //Selling
            var bestSellingProducts = await _mediator.Send(new GetProductSellingReportQueryRequest { StartDate = startDate, EndDate = endDate });
            var bestEarningProducts = await _mediator.Send(new GetProductEarningReportQueryRequest { StartDate = startDate, EndDate = endDate });

            var bestSellingCategories = await _mediator.Send(new GetCategorySellingReportQueryRequest { StartDate = startDate, EndDate = endDate });
            var bestEarningCategories = await _mediator.Send(new GetCategoryEarningReportQueryRequest { StartDate = startDate, EndDate = endDate });

            var bestSellingCustomers = await _mediator.Send(new GetCustomerSellingReportQueryRequest { StartDate = startDate, EndDate = endDate });
            var bestEarningCustomers = await _mediator.Send(new GetCustomerEarningReportQueryRequest { StartDate = startDate, EndDate = endDate });

            var bestSellingEmployees = await _mediator.Send(new GetEmployeeSellingReportQueryRequest { StartDate = startDate, EndDate = endDate });
            var bestEarningEmployees = await _mediator.Send(new GetEmployeeEarningReportQueryRequest { StartDate = startDate, EndDate = endDate });

            var bestSellingBrands = await _mediator.Send(new GetBrandSellingReportQueryRequest { StartDate = startDate, EndDate = endDate });
            var bestEarningBrands = await _mediator.Send(new GetBrandEarningReportQueryRequest { StartDate = startDate, EndDate = endDate });

            var bestSellingBranches = await _mediator.Send(new GetBranchSellingReportQueryRequest { StartDate = startDate, EndDate = endDate });
            var bestEarningBranches = await _mediator.Send(new GetBranchEarningReportQueryRequest { StartDate = startDate, EndDate = endDate });


            GetSalesReportQueryResponse getSalesReportQueryResponse = new GetSalesReportQueryResponse
            {
                //Selling
                BestSellingProductName = bestSellingProducts[0].ProductName,
                BestSellingProductQuantity = bestSellingProducts[0].TotalSales,

                BestSellingCategoryName = bestSellingCategories[0].CategoryName,
                BestSellingCategoryQuantity = bestSellingCategories[0].TotalSales,

                BestSellingBranchName = bestSellingBranches[0].BranchName,
                BestSellingBranchQuantity = bestSellingBranches[0].TotalSales,

                BestSellingEmployeeName = bestSellingEmployees[0].UserName,
                BestSellingEmployeeQuantity = bestSellingEmployees[0].TotalSales,

                BestSellingCustomerName = bestSellingCustomers[0].FullName,
                BestSellingCustomerQuantity = bestSellingCustomers[0].TotalSales,

                BestSellingBrandName = bestSellingBrands[0].BrandName,
                BestSellingBrandQuantity = bestSellingBrands[0].TotalSales,

                //Earning
                BestEarningProductName = bestEarningProducts[0].ProductName,
                BestEarningProductPrice = bestEarningProducts[0].TotalPrice,

                BestEarningCategoryName = bestEarningCategories[0].CategoryName,
                BestEarningCategoryPrice = bestEarningCategories[0].TotalPrice,

                BestEarningBranchName = bestEarningBranches[0].BranchName,
                BestEarningBranchPrice = bestEarningBranches[0].TotalPrice,

                BestEarningEmployeeName = bestEarningEmployees[0].UserName,
                BestEarningEmployeePrice = bestEarningEmployees[0].TotalPrice,

                BestEarningCustomerName = bestEarningCustomers[0].FullName,
                BestEarningCustomerPrice = bestEarningCustomers[0].TotalPrice,

                BestEarningBrandName = bestEarningBrands[0].BrandName,
                BestEarningBrandPrice = bestEarningBrands[0].TotalPrice

            };

            return getSalesReportQueryResponse;
        }
    }
}
