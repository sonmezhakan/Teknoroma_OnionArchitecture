using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Products;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Products.Command.Update
{
	public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, Unit>
	{
		private readonly IMapper _mapper;
		private readonly IProductService _productService;

		public UpdateProductCommandHandler(IMapper mapper,IProductService productService)
        {
			_mapper = mapper;
			_productService = productService;
		}
        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
		{
			Product product = await _productService.GetAsync(x => x.ID == request.ID);

			product = _mapper.Map(request, product);

			await _productService.UpdateAsync(product);

			return Unit.Value;
		}
	}
}
