using System.Linq.Expressions;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Services.AppUserProfiles
{
    public interface IAppUserProfileService
    {
        Task<IQueryable<AppUserProfile>> GetAllAsync(Expression<Func<AppUserProfile, bool>> filter = null);
        Task<AppUserProfile> GetAsync(Expression<Func<AppUserProfile, bool>> filter);

        Task<bool> AnyAsync(Expression<Func<AppUserProfile, bool>> filter);

        Task AddAsync(AppUserProfile appUserProfile);
        Task AddRangeAsync(List<AppUserProfile> appUserProfiles);

        Task UpdateAsync(AppUserProfile appUserProfile);
        Task UpdateRangeAsync(List<AppUserProfile> appUserProfiles);

        Task DeleteAsync(AppUserProfile appUserProfile);
        Task DeleteRangeAsync(List<AppUserProfile> appUserProfiles);
    }
}
