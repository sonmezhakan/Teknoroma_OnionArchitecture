using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Products;

namespace Teknoroma.Application.Features.Products.Queries.GetList
{
	public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, List<GetAllProductQueryResponse>>
	{
		private readonly IMapper _mapper;
		private readonly IProductService _productService;

		public GetAllProductQueryHandler(IMapper mapper,IProductService productService)
        {
			_mapper = mapper;
			_productService = productService;
		}
        public async Task<List<GetAllProductQueryResponse>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
		{
			var products = await _productService.GetAllAsync(); 

			List<GetAllProductQueryResponse> responses = _mapper.Map<List<GetAllProductQueryResponse>>(products.ToList());

			return responses;
		}
	}
}
