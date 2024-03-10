using MediatR;
using Teknoroma.Application.Services.Stocks;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Stocks.Command.Delete
{
	public class DeleteStockCommandHandler : IRequestHandler<DeleteStockCommandRequest, Unit>
	{
		private readonly IStockService _stockService;

		public DeleteStockCommandHandler(IStockService stockService)
        {
			_stockService = stockService;
		}
        public async Task<Unit> Handle(DeleteStockCommandRequest request, CancellationToken cancellationToken)
		{
			Stock stock = await _stockService.GetAsync(x=>x.BranchId == request.BranchId && x.ProductId == request.ProductId);

			await _stockService.DeleteAsync(stock);

			return Unit.Value;
		}
	}
}
