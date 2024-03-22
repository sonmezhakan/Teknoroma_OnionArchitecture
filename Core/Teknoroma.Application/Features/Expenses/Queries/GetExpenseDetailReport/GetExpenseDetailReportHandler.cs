using MediatR;
using Teknoroma.Application.Services.Repositories;

namespace Teknoroma.Application.Features.Expenses.Queries.GetExpenseDetailReport
{
	public class GetExpenseDetailReportHandler : IRequestHandler<GetExpenseDetailReportRequest, List<GetExpenseDetailReportResponse>>
	{
		private readonly IExpenseRepository _expenseRepository;

		public GetExpenseDetailReportHandler(IExpenseRepository expenseRepository)
        {
			_expenseRepository = expenseRepository;
		}
        public async Task<List<GetExpenseDetailReportResponse>> Handle(GetExpenseDetailReportRequest request, CancellationToken cancellationToken)
		{
			var expenses = await _expenseRepository.GetAllAsync(x=>x.ExpenseDate >= request.StartDate && x.ExpenseDate <= request.EndDate);

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
