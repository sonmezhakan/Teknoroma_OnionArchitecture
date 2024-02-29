using MediatR;

namespace Teknoroma.Application.Features.Employees.Queries.GetEmployeeDetailReport
{
    public class GetEmployeeDetailReportQueryRequest : IRequest<List<GetEmployeeDetailReportQueryResponse>>
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}
