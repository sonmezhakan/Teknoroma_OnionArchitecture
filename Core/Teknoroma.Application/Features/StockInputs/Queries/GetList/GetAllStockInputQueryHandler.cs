using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.StockInputs;

namespace Teknoroma.Application.Features.StockInputs.Queries.GetList
{
	public class GetAllStockInputQueryHandler : IRequestHandler<GetAllStockInputQueryRequest, List<GetAllStockInputQueryResponse>>
    {
        private readonly IMapper _mapper;
		private readonly IStockInputService _stockInputService;

		public GetAllStockInputQueryHandler(IMapper mapper,IStockInputService stockInputService)
        {
            _mapper = mapper;
			_stockInputService = stockInputService;
		}
        public async Task<List<GetAllStockInputQueryResponse>> Handle(GetAllStockInputQueryRequest request, CancellationToken cancellationToken)
        {
            var stockInputs = await _stockInputService.GetAllAsync();

            List<GetAllStockInputQueryResponse> getAllStockInputQueryResponses = _mapper.Map<List<GetAllStockInputQueryResponse>>(stockInputs.OrderByDescending(x=>x.StockEntryDate).ToList());

            return getAllStockInputQueryResponses;
        }
    }
}
