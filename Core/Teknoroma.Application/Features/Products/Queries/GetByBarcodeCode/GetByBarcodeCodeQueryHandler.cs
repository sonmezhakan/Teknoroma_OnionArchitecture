using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Repositories;

namespace Teknoroma.Application.Features.Products.Queries.GetByBarcodeCode
{
	public class GetByBarcodeCodeQueryHandler : IRequestHandler<GetByBarcodeCodeQueryRequest, GetByBarcodeCodeQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly IProductRepository _productRepository;

		public GetByBarcodeCodeQueryHandler(IMapper mapper, IProductRepository productRespository)
        {
			_mapper = mapper;
			_productRepository = productRespository;
		}
        public async Task<GetByBarcodeCodeQueryResponse> Handle(GetByBarcodeCodeQueryRequest request, CancellationToken cancellationToken)
		{
			var product = await _productRepository.GetAsync(x => x.BarcodeCode == request.BarcodeCode);

			GetByBarcodeCodeQueryResponse getByBarcodeCodeQueryResponse = _mapper.Map<GetByBarcodeCodeQueryResponse>(product);

			return getByBarcodeCodeQueryResponse;
		}
	}
}
