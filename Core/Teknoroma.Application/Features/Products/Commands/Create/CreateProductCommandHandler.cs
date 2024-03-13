using AutoMapper;
using MediatR;
using Teknoroma.Application.Features.Branches.Queries.GetAll;
using Teknoroma.Application.Features.Stocks.Command.Create;
using Teknoroma.Application.Services.Products;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Products.Command.Create
{
	public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, Unit>
	{
		private readonly IMapper _mapper;
		private readonly IProductService _productService;
		private readonly IMediator _mediator;

		public CreateProductCommandHandler(IMapper mapper,IProductService productService,IMediator mediator)
        {
			_mapper = mapper;
			_productService = productService;
			_mediator = mediator;
		}
        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
		{
			Product product = _mapper.Map<Product>(request);

			await _productService.AddAsync(product);

			//Tüm şubelere ürünün eklenmesi sağlanıyor
			var branches = await _mediator.Send(new GetAllBranchQueryRequest());

			foreach (var branch in branches)
			{
				CreateStockCommandRequest createStockCommandRequest = new CreateStockCommandRequest
				{
					BranchId = branch.ID,
					ProductId = product.ID,
					UnitsInStock = 0
				};
				await _mediator.Send(createStockCommandRequest);
			}

			return Unit.Value;
		}
	}
}
