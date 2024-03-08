using AutoMapper;
using MediatR;
using Teknoroma.Application.Features.AppUserProfiles.Rules;
using Teknoroma.Application.Services.AppUserProfiles;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.AppUserProfiles.Command.Update
{
    public class UpdateAppUserProfileCommandHandler : IRequestHandler<UpdateAppUserProfileCommandRequest, Unit>
    {
        private readonly IMapper _mapper;
		private readonly IAppUserProfileService _appUserProfileService;
        private readonly AppUserProfileBusinessRules _appUserProfileBusinessRules;

        public UpdateAppUserProfileCommandHandler(IMapper mapper,IAppUserProfileService appUserProfileService, AppUserProfileBusinessRules appUserProfileBusinessRules)
        {
            _mapper = mapper;
			_appUserProfileService = appUserProfileService;
            _appUserProfileBusinessRules = appUserProfileBusinessRules;
        }
        public async Task<Unit> Handle(UpdateAppUserProfileCommandRequest request, CancellationToken cancellationToken)
        {
            AppUserProfile appUserProfile = await _appUserProfileService.GetAsync(x => x.ID == request.ID);

            await _appUserProfileBusinessRules.NationalityNumberCannotBeDuplicatedWhenUpdated(appUserProfile.NationalityNumber,request.NationalityNumber);

            appUserProfile = _mapper.Map(request, appUserProfile);

            await _appUserProfileService.UpdateAsync(appUserProfile);

            return Unit.Value;
        }
    }
}
