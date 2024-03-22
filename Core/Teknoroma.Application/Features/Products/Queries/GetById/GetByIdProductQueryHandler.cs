using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Products.Queries.GetById
{
	public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly IProductRepository _productRepository;

		public GetByIdProductQueryHandler(IMapper mapper,IProductRepository productRespository)
        {
			_mapper = mapper;
			_productRepository = productRespository;
		}
        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
		{
			Product product = await _productRepository.GetAsync(x=>x.ID == request.ID);

			GetByIdProductQueryResponse getByIdProductQueryResponse = _mapper.Map<GetByIdProductQueryResponse>(product);

			return getByIdProductQueryResponse;
		}
	}
}
