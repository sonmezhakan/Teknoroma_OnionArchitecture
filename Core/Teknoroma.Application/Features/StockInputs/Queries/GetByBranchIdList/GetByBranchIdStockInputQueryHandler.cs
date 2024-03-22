using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Repositories;

namespace Teknoroma.Application.Features.StockInputs.Queries.GetByBranchIdList
{
	public class GetByBranchIdStockInputQueryHandler : IRequestHandler<GetByBranchIdStockInputQueryRequest, List<GetByBranchIdStockInputQueryResponse>>
    {
        private readonly IMapper _mapper;
		private readonly IStockInputRepository _stockInputRepository;

		public GetByBranchIdStockInputQueryHandler(IMapper mapper,IStockInputRepository stockInputRepository)
        {
            _mapper = mapper;
			_stockInputRepository = stockInputRepository;
		}
        public async Task<List<GetByBranchIdStockInputQueryResponse>> Handle(GetByBranchIdStockInputQueryRequest request, CancellationToken cancellationToken)
        {
            var stockInputs = await _stockInputRepository.GetAllAsync(x => x.BranchID == request.BranchId);

            List<GetByBranchIdStockInputQueryResponse> getByBranchIdStockInputQueryResponse = _mapper.Map<List<GetByBranchIdStockInputQueryResponse>>(stockInputs.OrderByDescending(x => x.StockEntryDate).ToList());

            return getByBranchIdStockInputQueryResponse;
        }
    }
}
