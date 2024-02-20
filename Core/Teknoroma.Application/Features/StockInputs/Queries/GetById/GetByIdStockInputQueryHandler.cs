using AutoMapper;
using MediatR;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.StockInputs.Queries.GetById
{
    public class GetByIdStockInputQueryHandler : IRequestHandler<GetByIdStockInputQueryRequest, GetByIdStockInputQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStockInputRepository _stockInputRepository;

        public GetByIdStockInputQueryHandler(IMapper mapper,IStockInputRepository stockInputRepository)
        {
            _mapper = mapper;
            _stockInputRepository = stockInputRepository;
        }
        public async Task<GetByIdStockInputQueryResponse> Handle(GetByIdStockInputQueryRequest request, CancellationToken cancellationToken)
        {
            StockInput stockInput = await _stockInputRepository.GetAsync(x=>x.ID == request.ID);

            GetByIdStockInputQueryResponse getByIdStockInputQueryResponse = _mapper.Map<GetByIdStockInputQueryResponse>(stockInput);

            return getByIdStockInputQueryResponse;
        }
    }
}
