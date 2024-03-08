using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;


namespace Teknoroma.Application.Features.Stocks.Queries.GetByBranchId
{
    public class GetByBranchIdStockQueryHandler : IRequestHandler<GetByBranchIdStockQueryRequest, GetByBranchIdStockQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStockRepository _stockRepository;

        public GetByBranchIdStockQueryHandler(IMapper mapper, IStockRepository stockRepository)
        {
            _mapper = mapper;
            _stockRepository = stockRepository;
        }

        public async Task<GetByBranchIdStockQueryResponse> Handle(GetByBranchIdStockQueryRequest request, CancellationToken cancellationToken)
        {
            Stock stock = await _stockRepository.GetAsync(x => x.BranchId == request.BranchID);

            GetByBranchIdStockQueryResponse response = _mapper.Map<GetByBranchIdStockQueryResponse>(stock);

            return response;
        }
    }
}
