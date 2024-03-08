using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Products;
using Teknoroma.Application.Services.Repositories;

namespace Teknoroma.Application.Features.Products.Queries.GetByBarcodeCode
{
	public class GetByBarcodeCodeQueryHandler : IRequestHandler<GetByBarcodeCodeQueryRequest, GetByBarcodeCodeQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly IProductService _productService;

		public GetByBarcodeCodeQueryHandler(IMapper mapper, IProductService productService)
        {
			_mapper = mapper;
			_productService = productService;
		}
        public async Task<GetByBarcodeCodeQueryResponse> Handle(GetByBarcodeCodeQueryRequest request, CancellationToken cancellationToken)
		{
			var product = await _productService.GetAsync(x => x.BarcodeCode == request.BarcodeCode);

			GetByBarcodeCodeQueryResponse getByBarcodeCodeQueryResponse = _mapper.Map<GetByBarcodeCodeQueryResponse>(product);

			return getByBarcodeCodeQueryResponse;
		}
	}
}
