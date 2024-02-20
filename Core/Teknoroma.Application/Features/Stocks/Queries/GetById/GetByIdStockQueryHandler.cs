using AutoMapper;
using MediatR;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Stocks.Queries.GetById
{
    public class GetByIdStockQueryHandler : IRequestHandler<GetByIdStockQueryRequest, GetByIdStockQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStockRepository _stockRepository;

        public GetByIdStockQueryHandler(IMapper mapper, IStockRepository stockRepository)
        {
            _mapper = mapper;
            _stockRepository = stockRepository;
        }

        public async Task<GetByIdStockQueryResponse> Handle(GetByIdStockQueryRequest request, CancellationToken cancellationToken)
        {
            Stock stock = await _stockRepository.GetAsync(x => x.BranchId == request.BranchID && x.ProductId == request.ProductID);

            GetByIdStockQueryResponse response = _mapper.Map<GetByIdStockQueryResponse>(stock);

            return response;
        }
    }
}
