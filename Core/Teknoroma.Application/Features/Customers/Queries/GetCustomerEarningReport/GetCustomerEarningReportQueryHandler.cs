using MediatR;
using Teknoroma.Application.Repositories;

namespace Teknoroma.Application.Features.Customers.Queries.GetCustomerEarningReport
{
    public class GetCustomerEarningReportQueryHandler : IRequestHandler<GetCustomerEarningReportQueryRequest, List<GetCustomerEarningReportQueryResponse>>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerEarningReportQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<GetCustomerEarningReportQueryResponse>> Handle(GetCustomerEarningReportQueryRequest request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetAllAsync();

            var bestEarningCustomers = customers.GroupBy(customer => customer.FullName)
            .Select(grouped => new
            {
                FullName = grouped.Key,
                TotalPrice = grouped.SelectMany(orders => orders.Orders
                .SelectMany(orderDetails => orderDetails.OrderDetails
                .Where(x => x.IsActive == true &&
                x.Order.OrderDate >= request.StartDate && x.Order.OrderDate <= request.EndDate)
                .Select(orderDetail=>orderDetail.Quantity * orderDetail.UnitPrice)))
                .Sum()
            }).OrderByDescending(x => x.TotalPrice).ToList();

            return new List<GetCustomerEarningReportQueryResponse>(bestEarningCustomers.Select(x=> new GetCustomerEarningReportQueryResponse
            {
                FullName  = x.FullName,
                TotalPrice = x.TotalPrice
            }));
        }
    }
}
