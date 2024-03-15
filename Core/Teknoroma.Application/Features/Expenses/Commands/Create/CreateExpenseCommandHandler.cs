using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.ExpenseServices;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Expenses.Commands.Create
{
	public class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommandRequest, Unit>
	{
		private readonly IExpenseService _expenseService;
		private readonly IMapper _mapper;

		public CreateExpenseCommandHandler(IExpenseService expenseService,IMapper mapper)
        {
			_expenseService = expenseService;
			_mapper = mapper;
		}
        public async Task<Unit> Handle(CreateExpenseCommandRequest request, CancellationToken cancellationToken)
		{
			Expense expense = _mapper.Map<Expense>(request);

			await _expenseService.AddAsync(expense);

			return Unit.Value;
		}
	}
}
