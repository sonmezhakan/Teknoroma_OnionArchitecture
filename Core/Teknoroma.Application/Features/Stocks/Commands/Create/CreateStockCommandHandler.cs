using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Stocks;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Stocks.Command.Create
{
	public class CreateStockCommandHandler : IRequestHandler<CreateStockCommandRequest, Unit>
    {
        private readonly IMapper _mapper;
		private readonly IStockService _stockService;

		public CreateStockCommandHandler(IMapper mapper, IStockService stockService)
        {
            _mapper = mapper;
			_stockService = stockService;
		}
        public async Task<Unit> Handle(CreateStockCommandRequest request, CancellationToken cancellationToken)
        {
            Stock stock = _mapper.Map<Stock>(request);

            await _stockService.AddAsync(stock);
            return Unit.Value;
        }
    }
}
