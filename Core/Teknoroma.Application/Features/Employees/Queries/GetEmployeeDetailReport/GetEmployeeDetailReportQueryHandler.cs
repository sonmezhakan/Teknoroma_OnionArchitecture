using MediatR;
using Teknoroma.Application.Services.Employees;

namespace Teknoroma.Application.Features.Employees.Queries.GetEmployeeDetailReport
{
	public class GetEmployeeDetailReportQueryHandler : IRequestHandler<GetEmployeeDetailReportQueryRequest, List<GetEmployeeDetailReportQueryResponse>>
    {
		private readonly IEmployeeService _employeeService;

		public GetEmployeeDetailReportQueryHandler(IEmployeeService employeeService)
        {
			_employeeService = employeeService;
		}
        public async Task<List<GetEmployeeDetailReportQueryResponse>> Handle(GetEmployeeDetailReportQueryRequest request, CancellationToken cancellationToken)
        {
            var employees = await _employeeService.GetAllAsync();

            List<GetEmployeeDetailReportQueryResponse> getByIdDetailReportQueryResponses = new List<GetEmployeeDetailReportQueryResponse>();

            foreach (var employee in employees.ToList())
            {
               
                foreach (var order in employee.Orders.Where(x=>x.IsActive ==true && x.OrderDate >= request.StartDate && x.OrderDate <= request.EndDate).ToList())
                {

                    foreach (var orderDetail in order.OrderDetails.Where(x=>x.IsActive == true).ToList())
                    {
                        if (getByIdDetailReportQueryResponses.Any(x => x.UserName == employee.AppUser.UserName && x.ProductName == orderDetail.Product.ProductName && x.BranchName == order.Branch.BranchName) == true)
                        {
                            var getListItem = getByIdDetailReportQueryResponses.FirstOrDefault(x => x.UserName == employee.AppUser.UserName && x.ProductName == orderDetail.Product.ProductName && x.BranchName == order.Branch.BranchName);

                            getListItem.TotalSales += orderDetail.Quantity;
                            getListItem.TotalPrice += orderDetail.Quantity * orderDetail.UnitPrice;
                        }
                        else
                        {
                            getByIdDetailReportQueryResponses.Add(new GetEmployeeDetailReportQueryResponse
                            {
                                UserName = employee.AppUser.UserName,
                                BranchName = order.Branch.BranchName,
                                ProductName = orderDetail.Product.ProductName,
                                TotalSales = orderDetail.Quantity,
                                TotalPrice = orderDetail.UnitPrice * orderDetail.Quantity
                            });
                        }
                    }
                }
            }

            return getByIdDetailReportQueryResponses;
        }
    }
}
