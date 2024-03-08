using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.AppUserProfiles;
using Teknoroma.Application.Services.Repositories;

namespace Teknoroma.Application.Features.AppUserProfiles.Quıeries.GetList
{
    public class GetAllAppUserProfileQueryHandler : IRequestHandler<GetAllAppUserProfileQueryRequest, List<GetAllAppUserProfileQueryResponse>>
    {
        private readonly IMapper _mapper;
		private readonly IAppUserProfileService _appUserProfileService;

		public GetAllAppUserProfileQueryHandler(IMapper mapper,IAppUserProfileService appUserProfileService)
        {
            _mapper = mapper;
			_appUserProfileService = appUserProfileService;
		}
        public async Task<List<GetAllAppUserProfileQueryResponse>> Handle(GetAllAppUserProfileQueryRequest request, CancellationToken cancellationToken)
        {
            var appUserProfileList = await _appUserProfileService.GetAllAsync();

            List<GetAllAppUserProfileQueryResponse> getAllAppUserProfileQueryResponses = _mapper.Map<List<GetAllAppUserProfileQueryResponse>>(appUserProfileList.ToList());

            return getAllAppUserProfileQueryResponses;
        }
    }
}
