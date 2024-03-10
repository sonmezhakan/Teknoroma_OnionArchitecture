using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Stocks;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Stocks.Command.Update
{
	public class UpdateStockCommandHandler : IRequestHandler<UpdateStockCommandRequest, Unit>
    {
        private readonly IMapper _mapper;
		private readonly IStockService _stockService;

		public UpdateStockCommandHandler(IMapper mapper, IStockService stockService)
        {
            _mapper = mapper;
			_stockService = stockService;
		}

        public async Task<Unit> Handle(UpdateStockCommandRequest request, CancellationToken cancellationToken)
        {
            Stock stock = await _stockService.GetAsync(x => x.BranchId == request.BranchId && x.ProductId == request.ProductId);

            stock = _mapper.Map(request, stock);
            await _stockService.UpdateAsync(stock);

            return Unit.Value;
        }
    }
}
