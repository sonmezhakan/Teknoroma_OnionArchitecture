using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Repositories;

namespace Teknoroma.Application.Features.Expenses.Queries.GetById
{
	public class GetByIdExpenseQueryHandler : IRequestHandler<GetByIdExpenseQueryRequest, GetByIdExpenseQueryResponse>
	{
		private readonly IExpenseRepository _expenseRepository;
		private readonly IMapper _mapper;

		public GetByIdExpenseQueryHandler(IExpenseRepository expenseRepository,IMapper mapper)
        {
			_expenseRepository = expenseRepository;
			_mapper = mapper;
		}
        public async Task<GetByIdExpenseQueryResponse> Handle(GetByIdExpenseQueryRequest request, CancellationToken cancellationToken)
		{
			var expense = await _expenseRepository.GetAsync(x => x.ID == request.ID);

			GetByIdExpenseQueryResponse getByIdExpenseQueryResponse = _mapper.Map<GetByIdExpenseQueryResponse>(expense);

			return getByIdExpenseQueryResponse;
		}
	}
}
