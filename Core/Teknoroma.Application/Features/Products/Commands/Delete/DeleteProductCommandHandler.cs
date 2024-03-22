using MediatR;
using Teknoroma.Application.Features.Stocks.Command.Delete;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Products.Command.Delete
{
	public class DeleteProductCommandHandler:IRequestHandler<DeleteProductCommandRequest, Unit>
	{
		private readonly IMediator _mediator;
		private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IMediator mediator,IProductRepository productRespository)
        {
			_mediator = mediator;
			_productRepository = productRespository;
		}

		public async Task<Unit> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
		{
			Product product = await _productRepository.GetAsync(x => x.ID == request.ID);

			await _productRepository.DeleteAsync(product);

			//Branchlerde bulunan productlar IsActive yapılıyor.
			var stocks = product.stocks.Where(x => x.ProductId == product.ID);

			foreach (var stock in stocks)
			{
				await _mediator.Send(new DeleteStockCommandRequest { BranchId = stock.BranchId, ProductId = stock.ProductId });
			}

            return Unit.Value;
		}
	}
}
