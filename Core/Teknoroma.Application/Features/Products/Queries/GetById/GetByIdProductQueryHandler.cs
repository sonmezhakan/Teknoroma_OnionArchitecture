using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Products;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Products.Queries.GetById
{
	public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly IProductService _productService;

		public GetByIdProductQueryHandler(IMapper mapper,IProductService productService)
        {
			_mapper = mapper;
			_productService = productService;
		}
        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
		{
			Product product = await _productService.GetAsync(x=>x.ID == request.ID);

			GetByIdProductQueryResponse getByIdProductQueryResponse = _mapper.Map<GetByIdProductQueryResponse>(product);

			return getByIdProductQueryResponse;
		}
	}
}
