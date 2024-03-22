using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Repositories;

namespace Teknoroma.Application.Features.Products.Queries.GetListSelectIdAndName
{
    public class GetAllSelectIdAndNameProductQueryHandler : IRequestHandler<GetAllSelectIdAndNameProductQueryRequest, List<GetAllSelectIdAndNameProductQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public GetAllSelectIdAndNameProductQueryHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<List<GetAllSelectIdAndNameProductQueryResponse>> Handle(GetAllSelectIdAndNameProductQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllSelectIdAndNameAsync();

            List<GetAllSelectIdAndNameProductQueryResponse> getAllSelectIdAndNameProductQueryResponses = _mapper.Map<List<GetAllSelectIdAndNameProductQueryResponse>>(products.ToList());

            return getAllSelectIdAndNameProductQueryResponses;
        }
    }
}
