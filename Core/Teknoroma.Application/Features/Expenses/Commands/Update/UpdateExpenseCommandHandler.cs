using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Expenses.Commands.Update
{
	public class UpdateExpenseCommandHandler : IRequestHandler<UpdateExpenseCommandRequest, Unit>
	{
		private readonly IExpenseRepository _expenseRepository;
		private readonly IMapper _mapper;

		public UpdateExpenseCommandHandler(IExpenseRepository expenseRepository,IMapper mapper)
        {
			_expenseRepository = expenseRepository;
			_mapper = mapper;
		}
        public async Task<Unit> Handle(UpdateExpenseCommandRequest request, CancellationToken cancellationToken)
		{
			Expense expense = await _expenseRepository.GetAsync(x => x.ID == request.ID);

			expense = _mapper.Map(request, expense);

			await _expenseRepository.UpdateAsync(expense);

			return Unit.Value;
		}
	}
}
