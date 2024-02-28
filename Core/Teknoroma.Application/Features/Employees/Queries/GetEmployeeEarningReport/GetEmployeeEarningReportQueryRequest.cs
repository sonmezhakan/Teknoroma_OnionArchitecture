using MediatR;

namespace Teknoroma.Application.Features.Employees.Queries.GetEmployeeEarningReport
{
    public class GetEmployeeEarningReportQueryRequest:IRequest<List<GetEmployeeEarningReportQueryResponse>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
