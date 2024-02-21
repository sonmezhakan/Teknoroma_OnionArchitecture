using AutoMapper;
using MediatR;
using Teknoroma.Application.Repositories;

namespace Teknoroma.Application.Features.AppUserProfiles.Quıeries.GetList
{
    public class GetAllAppUserProfileQueryHandler : IRequestHandler<GetAllAppUserProfileQueryRequest, List<GetAllAppUserProfileQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IAppUserProfileRepository _appUserProfileRepository;

        public GetAllAppUserProfileQueryHandler(IMapper mapper,IAppUserProfileRepository appUserProfileRepository)
        {
            _mapper = mapper;
            _appUserProfileRepository = appUserProfileRepository;
        }
        public async Task<List<GetAllAppUserProfileQueryResponse>> Handle(GetAllAppUserProfileQueryRequest request, CancellationToken cancellationToken)
        {
            var appUserProfileList = await _appUserProfileRepository.GetAllAsync();

            List<GetAllAppUserProfileQueryResponse> getAllAppUserProfileQueryResponses = _mapper.Map<List<GetAllAppUserProfileQueryResponse>>(appUserProfileList);

            return getAllAppUserProfileQueryResponses;
        }
    }
}
