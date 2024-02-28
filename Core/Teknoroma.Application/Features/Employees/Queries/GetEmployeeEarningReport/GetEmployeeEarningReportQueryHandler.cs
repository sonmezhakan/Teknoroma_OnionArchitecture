using MediatR;
using Teknoroma.Application.Repositories;

namespace Teknoroma.Application.Features.Employees.Queries.GetEmployeeEarningReport
{
    public class GetEmployeeEarningReportQueryHandler : IRequestHandler<GetEmployeeEarningReportQueryRequest, List<GetEmployeeEarningReportQueryResponse>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeEarningReportQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<List<GetEmployeeEarningReportQueryResponse>> Handle(GetEmployeeEarningReportQueryRequest request, CancellationToken cancellationToken)
        {
            var employees = await _employeeRepository.GetAllAsync();

            var bestEarningEmployees = employees.GroupBy(employee => employee.AppUser.UserName)
                .Select(grouped => new
                {
                    UserName = grouped.Key,
                    TotalPrice = grouped.SelectMany(orders => orders.Orders
                    .SelectMany(orderDetails => orderDetails.OrderDetails
                    .Where(x => x.IsActive == true &&
                    x.Order.OrderDate >= request.StartDate && x.Order.OrderDate <= request.EndDate)
                    .Select(orderDetail => orderDetail.Quantity * orderDetail.UnitPrice)))
                    .Sum()
                }).OrderByDescending(x => x.TotalPrice).ToList();

            return new List<GetEmployeeEarningReportQueryResponse>(bestEarningEmployees.Select(x => new GetEmployeeEarningReportQueryResponse
            {
                UserName = x.UserName,
                TotalPrice = x.TotalPrice
            })).ToList();
        }
    }
}
