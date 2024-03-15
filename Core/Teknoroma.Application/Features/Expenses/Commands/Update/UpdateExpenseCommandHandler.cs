using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.ExpenseServices;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Expenses.Commands.Update
{
	public class UpdateExpenseCommandHandler : IRequestHandler<UpdateExpenseCommandRequest, Unit>
	{
		private readonly IExpenseService _expenseService;
		private readonly IMapper _mapper;

		public UpdateExpenseCommandHandler(IExpenseService expenseService,IMapper mapper)
        {
			_expenseService = expenseService;
			_mapper = mapper;
		}
        public async Task<Unit> Handle(UpdateExpenseCommandRequest request, CancellationToken cancellationToken)
		{
			Expense expense = await _expenseService.GetAsync(x => x.ID == request.ID);

			expense = _mapper.Map(request, expense);

			await _expenseService.UpdateAsync(expense);

			return Unit.Value;
		}
	}
}
