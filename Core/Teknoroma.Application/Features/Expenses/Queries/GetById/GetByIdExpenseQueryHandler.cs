using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.ExpenseServices;

namespace Teknoroma.Application.Features.Expenses.Queries.GetById
{
	public class GetByIdExpenseQueryHandler : IRequestHandler<GetByIdExpenseQueryRequest, GetByIdExpenseQueryResponse>
	{
		private readonly IExpenseService _expenseService;
		private readonly IMapper _mapper;

		public GetByIdExpenseQueryHandler(IExpenseService expenseService,IMapper mapper)
        {
			_expenseService = expenseService;
			_mapper = mapper;
		}
        public async Task<GetByIdExpenseQueryResponse> Handle(GetByIdExpenseQueryRequest request, CancellationToken cancellationToken)
		{
			var expense = await _expenseService.GetAsync(x => x.ID == request.ID);

			GetByIdExpenseQueryResponse getByIdExpenseQueryResponse = _mapper.Map<GetByIdExpenseQueryResponse>(expense);

			return getByIdExpenseQueryResponse;
		}
	}
}
