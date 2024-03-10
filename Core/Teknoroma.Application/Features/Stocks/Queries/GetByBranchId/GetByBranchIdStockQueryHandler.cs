using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Stocks;
using Teknoroma.Domain.Entities;


namespace Teknoroma.Application.Features.Stocks.Queries.GetByBranchId
{
	public class GetByBranchIdStockQueryHandler : IRequestHandler<GetByBranchIdStockQueryRequest, GetByBranchIdStockQueryResponse>
    {
        private readonly IMapper _mapper;
		private readonly IStockService _stockService;

		public GetByBranchIdStockQueryHandler(IMapper mapper, IStockService stockService)
        {
            _mapper = mapper;
			_stockService = stockService;
		}

        public async Task<GetByBranchIdStockQueryResponse> Handle(GetByBranchIdStockQueryRequest request, CancellationToken cancellationToken)
        {
            Stock stock = await _stockService.GetAsync(x => x.BranchId == request.BranchID);

            GetByBranchIdStockQueryResponse response = _mapper.Map<GetByBranchIdStockQueryResponse>(stock);

            return response;
        }
    }
}
