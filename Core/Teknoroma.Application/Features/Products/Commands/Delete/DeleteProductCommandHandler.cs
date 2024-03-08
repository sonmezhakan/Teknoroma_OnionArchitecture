using MediatR;
using Teknoroma.Application.Features.Stocks.Command.Delete;
using Teknoroma.Application.Services.Products;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Products.Command.Delete
{
	public class DeleteProductCommandHandler:IRequestHandler<DeleteProductCommandRequest, Unit>
	{
		private readonly IMediator _mediator;
		private readonly IProductService _productService;

        public DeleteProductCommandHandler(IMediator mediator,IProductService productService)
        {
			_mediator = mediator;
			_productService = productService;
		}

		public async Task<Unit> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
		{
			Product product = await _productService.GetAsync(x => x.ID == request.ID);

			await _productService.DeleteAsync(product);

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
