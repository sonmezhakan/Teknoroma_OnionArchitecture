using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Repositories;

namespace Teknoroma.Application.Features.Expenses.Queries.GetList
{
	public class GetAllExpenseQueryHandler : IRequestHandler<GetAllExpenseQueryRequest, List<GetAllExpenseQueryResponse>>
	{
		private readonly IExpenseRepository _expenseRepository;
		private readonly IMapper _mapper;

		public GetAllExpenseQueryHandler(IExpenseRepository expenseRepository,IMapper mapper)
        {
			_expenseRepository = expenseRepository;
			_mapper = mapper;
		}
        public async Task<List<GetAllExpenseQueryResponse>> Handle(GetAllExpenseQueryRequest request, CancellationToken cancellationToken)
		{
			var expenses = await _expenseRepository.GetAllAsync();

			List<GetAllExpenseQueryResponse> getAllExpenseQueryResponses = _mapper.Map<List<GetAllExpenseQueryResponse>>(expenses.ToList());

			return getAllExpenseQueryResponses;
		}
	}
}
