using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Products.Command.Update
{
	public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, Unit>
	{
		private readonly IMapper _mapper;
		private readonly IProductRepository _productRepository;

		public UpdateProductCommandHandler(IMapper mapper,IProductRepository productRespository)
        {
			_mapper = mapper;
			_productRepository = productRespository;
		}
        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
		{
			Product product = await _productRepository.GetAsync(x => x.ID == request.ID);

			product = _mapper.Map(request, product);

			await _productRepository.UpdateAsync(product);

			return Unit.Value;
		}
	}
}
