using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Application.Services.Stocks;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Stocks.Queries.GetById
{
    public class GetByIdStockQueryHandler : IRequestHandler<GetByIdStockQueryRequest, GetByIdStockQueryResponse>
    {
        private readonly IMapper _mapper;
		private readonly IStockService _stockService;

		public GetByIdStockQueryHandler(IMapper mapper, IStockService stockService)
        {
            _mapper = mapper;
			_stockService = stockService;
		}

        public async Task<GetByIdStockQueryResponse> Handle(GetByIdStockQueryRequest request, CancellationToken cancellationToken)
        {
            Stock stock = await _stockService.GetAsync(x => x.BranchId == request.BranchID && x.ProductId == request.ProductID);

            GetByIdStockQueryResponse response = _mapper.Map<GetByIdStockQueryResponse>(stock);

            return response;
        }
    }
}
