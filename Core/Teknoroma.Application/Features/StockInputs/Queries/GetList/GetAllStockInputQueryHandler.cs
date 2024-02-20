using AutoMapper;
using MediatR;
using Teknoroma.Application.Repositories;

namespace Teknoroma.Application.Features.StockInputs.Queries.GetList
{
    public class GetAllStockInputQueryHandler : IRequestHandler<GetAllStockInputQueryRequest, List<GetAllStockInputQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IStockInputRepository _stockInputRepository;

        public GetAllStockInputQueryHandler(IMapper mapper,IStockInputRepository stockInputRepository)
        {
            _mapper = mapper;
            _stockInputRepository = stockInputRepository;
        }
        public async Task<List<GetAllStockInputQueryResponse>> Handle(GetAllStockInputQueryRequest request, CancellationToken cancellationToken)
        {
            var stockInputs = await _stockInputRepository.GetAllAsync();

            List<GetAllStockInputQueryResponse> getAllStockInputQueryResponses = _mapper.Map<List<GetAllStockInputQueryResponse>>(stockInputs.OrderByDescending(x=>x.StockEntryDate));

            return getAllStockInputQueryResponses;
        }
    }
}
