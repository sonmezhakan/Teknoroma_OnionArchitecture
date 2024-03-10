using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.StockInputs;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.StockInputs.Queries.GetById
{
	public class GetByIdStockInputQueryHandler : IRequestHandler<GetByIdStockInputQueryRequest, GetByIdStockInputQueryResponse>
    {
        private readonly IMapper _mapper;
		private readonly IStockInputService _stockInputService;

		public GetByIdStockInputQueryHandler(IMapper mapper,IStockInputService stockInputService)
        {
            _mapper = mapper;
			_stockInputService = stockInputService;
		}
        public async Task<GetByIdStockInputQueryResponse> Handle(GetByIdStockInputQueryRequest request, CancellationToken cancellationToken)
        {
            StockInput stockInput = await _stockInputService.GetAsync(x=>x.ID == request.ID);

            GetByIdStockInputQueryResponse getByIdStockInputQueryResponse = _mapper.Map<GetByIdStockInputQueryResponse>(stockInput);

            return getByIdStockInputQueryResponse;
        }
    }
}
