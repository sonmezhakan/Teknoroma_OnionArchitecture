using Teknoroma.Application.Exceptions.Types;
using Teknoroma.Application.Features.AppUserProfiles.Contants;
using Teknoroma.Application.Services.Repositories;

namespace Teknoroma.Application.Features.AppUserProfiles.Rules
{
    public class AppUserProfileBusinessRules
    {
        private readonly IAppUserProfileRepository _appUserProfileRepository;

        public AppUserProfileBusinessRules(IAppUserProfileRepository appUserProfileRepository)
        {
            _appUserProfileRepository = appUserProfileRepository;
        }

        public async Task NationalityNumberCannotBeDuplicatedWhenInserted(string? nationalityNumber)
        {
            if(nationalityNumber != null)
            {
                bool result = await _appUserProfileRepository.AnyAsync(x => x.NationalityNumber == nationalityNumber);

                if (result)
                    throw new BusinessException(AppUserProfilesMessages.NationalityNumberExists);
            }
        }

        public async Task NationalityNumberCannotBeDuplicatedWhenUpdated(string oldNationalityNumber, string newNationalityNumber)
        {
            if (oldNationalityNumber != newNationalityNumber)
            {
                bool result = await _appUserProfileRepository.AnyAsync(x => x.NationalityNumber == newNationalityNumber);

                if (result)
                    throw new BusinessException(AppUserProfilesMessages.NationalityNumberExists);
            }

        }
    }
}
