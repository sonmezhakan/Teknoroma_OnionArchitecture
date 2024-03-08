using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.AppUserProfiles;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.AppUserProfiles.Quıeries.GetById
{
	public class GetByIdAppUserProfileQueryHandler : IRequestHandler<GetByIdAppUserProfileQueryRequest, GetByIdAppUserProfileQueryResponse>
    {
        private readonly IMapper _mapper;
		private readonly IAppUserProfileService _appUserProfileService;

        public GetByIdAppUserProfileQueryHandler(IMapper mapper,IAppUserProfileService appUserProfileService)
        {
            _mapper = mapper;
			_appUserProfileService = appUserProfileService;
        }

        public async Task<GetByIdAppUserProfileQueryResponse> Handle(GetByIdAppUserProfileQueryRequest request, CancellationToken cancellationToken)
        {
            AppUserProfile appUserProfile = await _appUserProfileService.GetAsync(x => x.ID == request.ID);

            GetByIdAppUserProfileQueryResponse appUserProfileQueryResponse = _mapper.Map<GetByIdAppUserProfileQueryResponse>(appUserProfile);

            return appUserProfileQueryResponse;
        }
    }
}
