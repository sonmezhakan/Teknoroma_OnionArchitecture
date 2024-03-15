using MediatR;
using Teknoroma.Application.Services.ExpenseServices;

namespace Teknoroma.Application.Features.Expenses.Commands.Delete
{
	public class DeleteExpenseCommandHandler : IRequestHandler<DeleteExpenseCommandRequest, Unit>
	{
		private readonly IExpenseService _expenseService;

		public DeleteExpenseCommandHandler(IExpenseService expenseService)
        {
			_expenseService = expenseService;
		}
        public async Task<Unit> Handle(DeleteExpenseCommandRequest request, CancellationToken cancellationToken)
		{
			var expense = await _expenseService.GetAsync(x=>x.ID == request.ID);

			await _expenseService.DeleteAsync(expense);

			return Unit.Value;
		}
	}
}
