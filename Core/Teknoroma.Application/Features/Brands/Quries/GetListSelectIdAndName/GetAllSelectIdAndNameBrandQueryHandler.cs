using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Repositories;

namespace Teknoroma.Application.Features.Brands.Quries.GetListSelectIdAndName
{
    public class GetAllSelectIdAndNameBrandQueryHandler : IRequestHandler<GetAllSelectIdAndNameBrandQueryRequest, List<GetAllSelectIdAndNameBrandQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBrandRepository _brandRepository;

        public GetAllSelectIdAndNameBrandQueryHandler(IMapper mapper,IBrandRepository brandRepository)
        {
            _mapper = mapper;
            _brandRepository = brandRepository;
        }
        public async Task<List<GetAllSelectIdAndNameBrandQueryResponse>> Handle(GetAllSelectIdAndNameBrandQueryRequest request, CancellationToken cancellationToken)
        {
            var brands = await _brandRepository.GetAllSelectIdAndNameAsync();

            List<GetAllSelectIdAndNameBrandQueryResponse> getAllSelectIdAndNameBrandQueryResponses = _mapper.Map<List<GetAllSelectIdAndNameBrandQueryResponse>>(brands.ToList());

            return getAllSelectIdAndNameBrandQueryResponses;
        }
    }
}
