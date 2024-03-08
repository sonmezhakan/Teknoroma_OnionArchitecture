using MediatR;
using Teknoroma.Application.Services.Customers;

namespace Teknoroma.Application.Features.Customers.Queries.GetCustomerSellingReport
{
	public class GetCustomerSellingReportQueryHandler : IRequestHandler<GetCustomerSellingReportQueryRequest, List<GetCustomerSellingReportQueryResponse>>
    {
		private readonly ICustomerService _customerService;

		public GetCustomerSellingReportQueryHandler(ICustomerService customerService)
        {
			_customerService = customerService;
		}
        public async Task<List<GetCustomerSellingReportQueryResponse>> Handle(GetCustomerSellingReportQueryRequest request, CancellationToken cancellationToken)
        {
            var customers = await _customerService.GetAllAsync();

            var bestSellingReport = customers.GroupBy(customer => customer.FullName)
                .Select(grouped => new
                {
                    FullName = grouped.Key,
                    TotalSales = grouped.SelectMany(orders => orders.Orders
                    .Where(x => x.IsActive == true &&
                    x.OrderDate >= request.StartDate && x.OrderDate <= request.EndDate)).Count()
                }).OrderByDescending(x => x.TotalSales).ToList();

            return new List<GetCustomerSellingReportQueryResponse>(bestSellingReport.Select(x => new GetCustomerSellingReportQueryResponse
            {
                FullName = x.FullName,
                TotalSales = x.TotalSales
            })).ToList();
        }
    }
}
