using MediatR;

namespace Teknoroma.Application.Features.Employees.Queries.GetEmployeeDetailReport
{
    public class GetEmployeeDetailReportQueryRequest : IRequest<List<GetEmployeeDetailReportQueryResponse>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
