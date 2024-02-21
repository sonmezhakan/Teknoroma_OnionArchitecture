using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;
using Teknoroma.Persistence.Context;

namespace Teknoroma.Persistence.Repositories
{
    public class AppUserProfileRepository : BaseRepository<AppUserProfile>, IAppUserProfileRepository
    {
        public AppUserProfileRepository(TeknoromaContext context) : base(context)
        {
        }
    }
}
