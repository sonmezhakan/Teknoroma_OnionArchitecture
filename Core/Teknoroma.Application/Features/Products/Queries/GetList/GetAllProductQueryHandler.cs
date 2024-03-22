using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Repositories;

namespace Teknoroma.Application.Features.Products.Queries.GetList
{
	public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, List<GetAllProductQueryResponse>>
	{
		private readonly IMapper _mapper;
		private readonly IProductRepository _productRepository;

		public GetAllProductQueryHandler(IMapper mapper,IProductRepository productRespository)
        {
			_mapper = mapper;
			_productRepository = productRespository;
		}
        public async Task<List<GetAllProductQueryResponse>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
		{
			var products = await _productRepository.GetAllAsync(); 

			List<GetAllProductQueryResponse> responses = _mapper.Map<List<GetAllProductQueryResponse>>(products.ToList());

			return responses;
		}
	}
}
