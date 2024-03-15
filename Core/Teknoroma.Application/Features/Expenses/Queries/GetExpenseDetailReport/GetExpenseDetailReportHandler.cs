using MediatR;
using Teknoroma.Application.Services.ExpenseServices;

namespace Teknoroma.Application.Features.Expenses.Queries.GetExpenseDetailReport
{
	public class GetExpenseDetailReportHandler : IRequestHandler<GetExpenseDetailReportRequest, List<GetExpenseDetailReportResponse>>
	{
		private readonly IExpenseService _expenseService;

		public GetExpenseDetailReportHandler(IExpenseService expenseService)
        {
			_expenseService = expenseService;
		}
        public async Task<List<GetExpenseDetailReportResponse>> Handle(GetExpenseDetailReportRequest request, CancellationToken cancellationToken)
		{
			var expenses = await _expenseService.GetAllAsync(x=>x.ExpenseDate >= request.StartDate && x.ExpenseDate <= request.EndDate);

			var expenseReport = expenses.GroupBy(expense=> expense.Title)
				.Select(grouped=> new
				{
					Title = grouped.Key,
					TotalExpensePrice = grouped.Select(expense=>expense.Price).Sum()
				}).OrderByDescending(x=>x.TotalExpensePrice).ToList();

			return new List<GetExpenseDetailReportResponse>(expenseReport.Select(x => new GetExpenseDetailReportResponse
			{
				Title = x.Title,
				TotalExpensePrice = x.TotalExpensePrice
			}));
		}
	}
}
