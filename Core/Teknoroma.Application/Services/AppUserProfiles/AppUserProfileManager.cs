using System.Linq.Expressions;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Services.AppUserProfiles
{
    public class AppUserProfileManager : IAppUserProfileService
    {
        private readonly IAppUserProfileRepository _appUserProfileRepository;

        public AppUserProfileManager(IAppUserProfileRepository appUserProfileRepository)
        {
            _appUserProfileRepository = appUserProfileRepository;
        }
        public async Task AddAsync(AppUserProfile appUserProfile)
        {
            await _appUserProfileRepository.AddAsync(appUserProfile);
        }

        public async Task AddRangeAsync(List<AppUserProfile> appUserProfiles)
        {
            await _appUserProfileRepository.AddRangeAsync(appUserProfiles);
        }

        public async Task<bool> AnyAsync(Expression<Func<AppUserProfile, bool>> filter)
        {
           var result = await _appUserProfileRepository.AnyAsync(filter);

            return result;
        }

        public async Task DeleteAsync(AppUserProfile appUserProfile)
        {
            await _appUserProfileRepository.DeleteAsync(appUserProfile);
        }

        public async Task DeleteRangeAsync(List<AppUserProfile> appUserProfiles)
        {
            await _appUserProfileRepository.DeleteRangeAsync(appUserProfiles);
        }

        public async Task<IQueryable<AppUserProfile>> GetAllAsync(Expression<Func<AppUserProfile, bool>> filter = null)
        {
            var result = await _appUserProfileRepository.GetAllAsync(filter);

            return result;
        }

        public async Task<AppUserProfile> GetAsync(Expression<Func<AppUserProfile, bool>> filter)
        {
            var result = await _appUserProfileRepository.GetAsync(filter);

            return result;
        }

        public async Task UpdateAsync(AppUserProfile appUserProfile)
        {
            await _appUserProfileRepository.UpdateAsync(appUserProfile);
        }

        public async Task UpdateRangeAsync(List<AppUserProfile> appUserProfiles)
        {
            await _appUserProfileRepository.UpdateRangeAsync(appUserProfiles);
        }
    }
}
