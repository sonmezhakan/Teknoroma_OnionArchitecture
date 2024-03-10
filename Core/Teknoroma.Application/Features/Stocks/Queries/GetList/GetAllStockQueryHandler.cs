using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Stocks;

namespace Teknoroma.Application.Features.Stocks.Queries.GetList
{
	public class GetAllStockQueryHandler : IRequestHandler<GetAllStockQueryRequest, List<GetAllStockQueryResponse>>
    {
        private readonly IMapper _mapper;
		private readonly IStockService _stockService;

		public GetAllStockQueryHandler(IMapper mapper, IStockService stockService)
        {
            _mapper = mapper;
			_stockService = stockService;
		}
        public async Task<List<GetAllStockQueryResponse>> Handle(GetAllStockQueryRequest request, CancellationToken cancellationToken)
        {
            var stocks = request.ID == null ? await _stockService.GetAllAsync() :
                                              await _stockService.GetAllAsync(x => x.BranchId == request.ID);

            List<GetAllStockQueryResponse> responses = _mapper.Map<List<GetAllStockQueryResponse>>(stocks.ToList());

            return responses;
        }
    }
}
