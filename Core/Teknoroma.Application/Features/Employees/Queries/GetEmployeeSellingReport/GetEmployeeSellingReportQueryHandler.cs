using MediatR;
using Teknoroma.Application.Services.Repositories;

namespace Teknoroma.Application.Features.Employees.Queries.GetEmployeeSellingReport
{
	public class GetEmployeeSellingReportQueryHandler : IRequestHandler<GetEmployeeSellingReportQueryRequest, List<GetEmployeeSellingReportQueryResponse>>
    {
		private readonly IEmployeeRepository _employeeRepository;

		public GetEmployeeSellingReportQueryHandler(IEmployeeRepository employeeRepository)
        {
			_employeeRepository = employeeRepository;
		}
        public async Task<List<GetEmployeeSellingReportQueryResponse>> Handle(GetEmployeeSellingReportQueryRequest request, CancellationToken cancellationToken)
        {
            var employees = await _employeeRepository.GetFullAll();

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
