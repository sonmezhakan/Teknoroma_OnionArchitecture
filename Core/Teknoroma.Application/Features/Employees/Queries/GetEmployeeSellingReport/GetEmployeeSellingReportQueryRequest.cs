using MediatR;

namespace Teknoroma.Application.Features.Employees.Queries.GetEmployeeSellingReport
{
    public class GetEmployeeSellingReportQueryRequest:IRequest<List<GetEmployeeSellingReportQueryResponse>>
    {
        public DateTime StarDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
