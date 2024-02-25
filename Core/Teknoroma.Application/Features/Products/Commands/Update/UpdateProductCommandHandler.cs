using AutoMapper;
using MediatR;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Products.Command.Update
{
	public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, Unit>
	{
		private readonly IMapper _mapper;
		private readonly IProductRepository _productRepository;

		public UpdateProductCommandHandler(IMapper mapper,IProductRepository productRepository)
        {
			_mapper = mapper;
			_productRepository = productRepository;
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
