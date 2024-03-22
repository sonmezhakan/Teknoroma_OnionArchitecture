using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Services.Repositories
{
    public interface IBranchRepository : IBaseRepository<Branch>
    {
        Task<IQueryable<Branch>> GetAllSelectIdAndNameAsync();
    }
}
