using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.ExpenseServices;

namespace Teknoroma.Application.Features.Expenses.Queries.GetList
{
	public class GetAllExpenseQueryHandler : IRequestHandler<GetAllExpenseQueryRequest, List<GetAllExpenseQueryResponse>>
	{
		private readonly IExpenseService _expenseService;
		private readonly IMapper _mapper;

		public GetAllExpenseQueryHandler(IExpenseService expenseService,IMapper mapper)
        {
			_expenseService = expenseService;
			_mapper = mapper;
		}
        public async Task<List<GetAllExpenseQueryResponse>> Handle(GetAllExpenseQueryRequest request, CancellationToken cancellationToken)
		{
			var expenses = await _expenseService.GetAllAsync();

			List<GetAllExpenseQueryResponse> getAllExpenseQueryResponses = _mapper.Map<List<GetAllExpenseQueryResponse>>(expenses.ToList());

			return getAllExpenseQueryResponses;
		}
	}
}
