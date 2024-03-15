using MediatR;

namespace Teknoroma.Application.Features.Expenses.Queries.GetExpenseDetailReport
{
	public class GetExpenseDetailReportRequest:IRequest<List<GetExpenseDetailReportResponse>>
	{
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
