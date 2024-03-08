using MediatR;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Stocks.Command.Delete
{
    public class DeleteStockCommandHandler : IRequestHandler<DeleteStockCommandRequest, Unit>
	{
		private readonly IStockRepository _stockRepository;

		public DeleteStockCommandHandler(IStockRepository stockRepository)
        {
			_stockRepository = stockRepository;
		}
        public async Task<Unit> Handle(DeleteStockCommandRequest request, CancellationToken cancellationToken)
		{
			Stock stock = await _stockRepository.GetAsync(x=>x.BranchId == request.BranchId && x.ProductId == request.ProductId);

			await _stockRepository.DeleteAsync(stock);

			return Unit.Value;
		}
	}
}
