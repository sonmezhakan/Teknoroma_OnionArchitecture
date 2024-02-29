using MediatR;

namespace Teknoroma.Application.Features.Employees.Queries.GetEmployeeSellingReport
{
    public class GetEmployeeSellingReportQueryRequest:IRequest<List<GetEmployeeSellingReportQueryResponse>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
