using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.StockInputs;

namespace Teknoroma.Application.Features.StockInputs.Queries.GetByBranchIdList
{
	public class GetByBranchIdStockInputQueryHandler : IRequestHandler<GetByBranchIdStockInputQueryRequest, List<GetByBranchIdStockInputQueryResponse>>
    {
        private readonly IMapper _mapper;
		private readonly IStockInputService _stockInputService;

		public GetByBranchIdStockInputQueryHandler(IMapper mapper,IStockInputService stockInputService)
        {
            _mapper = mapper;
			_stockInputService = stockInputService;
		}
        public async Task<List<GetByBranchIdStockInputQueryResponse>> Handle(GetByBranchIdStockInputQueryRequest request, CancellationToken cancellationToken)
        {
            var stockInputs = _stockInputService.GetAllAsync().Result.Where(x=>x.BranchID == request.BranchId);

            List<GetByBranchIdStockInputQueryResponse> getByBranchIdStockInputQueryResponse = _mapper.Map<List<GetByBranchIdStockInputQueryResponse>>(stockInputs.OrderByDescending(x => x.StockEntryDate).ToList());

            return getByBranchIdStockInputQueryResponse;
        }
    }
}
