using MediatR;
using Teknoroma.Application.Services.Repositories;

namespace Teknoroma.Application.Features.Expenses.Commands.Delete
{
	public class DeleteExpenseCommandHandler : IRequestHandler<DeleteExpenseCommandRequest, Unit>
	{
		private readonly IExpenseRepository _expenseRepository;

		public DeleteExpenseCommandHandler(IExpenseRepository expenseRepository)
        {
			_expenseRepository = expenseRepository;
		}
        public async Task<Unit> Handle(DeleteExpenseCommandRequest request, CancellationToken cancellationToken)
		{
			var expense = await _expenseRepository.GetAsync(x=>x.ID == request.ID);

			await _expenseRepository.DeleteAsync(expense);

			return Unit.Value;
		}
	}
}
