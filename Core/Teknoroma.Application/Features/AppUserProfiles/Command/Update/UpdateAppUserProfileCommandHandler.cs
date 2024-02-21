using AutoMapper;
using MediatR;
using Teknoroma.Application.Features.AppUserProfiles.Rules;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.AppUserProfiles.Command.Update
{
    public class UpdateAppUserProfileCommandHandler : IRequestHandler<UpdateAppUserProfileCommandRequest, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IAppUserProfileRepository _appUserProfileRepository;
        private readonly AppUserProfileBusinessRules _appUserProfileBusinessRules;

        public UpdateAppUserProfileCommandHandler(IMapper mapper,IAppUserProfileRepository appUserProfileRepository, AppUserProfileBusinessRules appUserProfileBusinessRules)
        {
            _mapper = mapper;
            _appUserProfileRepository = appUserProfileRepository;
            _appUserProfileBusinessRules = appUserProfileBusinessRules;
        }
        public async Task<Unit> Handle(UpdateAppUserProfileCommandRequest request, CancellationToken cancellationToken)
        {
            AppUserProfile appUserProfile = await _appUserProfileRepository.GetAsync(x => x.ID == request.ID);

            await _appUserProfileBusinessRules.NationalityNumberCannotBeDuplicatedWhenUpdated(appUserProfile.NationalityNumber,request.NationalityNumber);

            appUserProfile = _mapper.Map(request, appUserProfile);

            await _appUserProfileRepository.UpdateAsync(appUserProfile);

            return Unit.Value;
        }
    }
}
