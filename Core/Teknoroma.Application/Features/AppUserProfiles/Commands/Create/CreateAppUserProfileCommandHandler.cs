using AutoMapper;
using MediatR;
using Teknoroma.Application.Features.AppUserProfiles.Rules;
using Teknoroma.Application.Services.AppUserProfiles;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.AppUserProfiles.Command.Create
{
	public class CreateAppUserProfileCommandHandler : IRequestHandler<CreateAppUserProfileCommandRequest, Unit>
    {
        private readonly IMapper _mapper;
		private readonly IAppUserProfileService _appUserProfileService;
		private readonly AppUserProfileBusinessRules _appUserProfileBusinessRules;

        public CreateAppUserProfileCommandHandler(IMapper mapper,IAppUserProfileService appUserProfileService,AppUserProfileBusinessRules appUserProfileBusinessRules)
        {
            _mapper = mapper;
			_appUserProfileService = appUserProfileService;
			_appUserProfileBusinessRules = appUserProfileBusinessRules;
        }
        public async Task<Unit> Handle(CreateAppUserProfileCommandRequest request, CancellationToken cancellationToken)
        {
            AppUserProfile appUserProfile = _mapper.Map<AppUserProfile>(request);

            await _appUserProfileService.AddAsync(appUserProfile);

            return Unit.Value;
        }
    }
}
