using AutoMapper;
using MediatR;
using Teknoroma.Application.Repositories;

namespace Teknoroma.Application.Features.Stocks.Queries.GetList
{
    public class GetAllStockQueryHandler : IRequestHandler<GetAllStockQueryRequest, List<GetAllStockQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IStockRepository _stockRepository;

        public GetAllStockQueryHandler(IMapper mapper, IStockRepository stockRepository)
        {
            _mapper = mapper;
            _stockRepository = stockRepository;
        }
        public async Task<List<GetAllStockQueryResponse>> Handle(GetAllStockQueryRequest request, CancellationToken cancellationToken)
        {
            var stocks = request.ID == null ? await _stockRepository.GetAllAsync() :
                                                      await _stockRepository.GetAllAsync(x => x.BranchId == request.ID);

            List<GetAllStockQueryResponse> responses = _mapper.Map<List<GetAllStockQueryResponse>>(stocks);

            return responses;
        }
    }
}
