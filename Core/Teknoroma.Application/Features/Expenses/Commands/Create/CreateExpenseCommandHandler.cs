using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Expenses.Commands.Create
{
	public class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommandRequest, Unit>
	{
		private readonly IExpenseRepository _expenseRepository;
		private readonly IMapper _mapper;

		public CreateExpenseCommandHandler(IExpenseRepository expenseRepository,IMapper mapper)
        {
			_expenseRepository = expenseRepository;
			_mapper = mapper;
		}
        public async Task<Unit> Handle(CreateExpenseCommandRequest request, CancellationToken cancellationToken)
		{
			Expense expense = _mapper.Map<Expense>(request);

			await _expenseRepository.AddAsync(expense);

			return Unit.Value;
		}
	}
}
