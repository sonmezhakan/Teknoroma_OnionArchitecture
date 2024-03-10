using MediatR;
using Teknoroma.Application.Services.Employees;

namespace Teknoroma.Application.Features.Employees.Queries.GetEmployeeSellingReport
{
	public class GetEmployeeSellingReportQueryHandler : IRequestHandler<GetEmployeeSellingReportQueryRequest, List<GetEmployeeSellingReportQueryResponse>>
    {
		private readonly IEmployeeService _employeeService;

		public GetEmployeeSellingReportQueryHandler(IEmployeeService employeeService)
        {
			_employeeService = employeeService;
		}
        public async Task<List<GetEmployeeSellingReportQueryResponse>> Handle(GetEmployeeSellingReportQueryRequest request, CancellationToken cancellationToken)
        {
            var employees = await _employeeService.GetFullAll();

            var bestSellingEmployees = employees.GroupBy(employee=>employee.AppUser.UserName)
                .Select(grouped=> new
                {
                    UserName = grouped.Key,
                    TotalSales = grouped.SelectMany(orders=>orders.Orders
                    .Where(x=>x.IsActive == true &&
                    x.OrderDate >= request.StartDate && x.OrderDate <=request.EndDate))
                    .Count()
                }).OrderByDescending(x=>x.TotalSales).ToList();

            return new List<GetEmployeeSellingReportQueryResponse>(bestSellingEmployees.Select(x => new GetEmployeeSellingReportQueryResponse
            {
                UserName = x.UserName,
                TotalSales = x.TotalSales
            })).ToList();
        }
    }
}
