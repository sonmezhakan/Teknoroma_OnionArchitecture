using System.Linq.Expressions;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Services.Branches
{
    public interface IBranchService
    {
        Task<IQueryable<Branch>> GetAllAsync(Expression<Func<Branch, bool>> filter = null);
        Task<Branch> GetAsync(Expression<Func<Branch, bool>> filter);

        Task<bool> AnyAsync(Expression<Func<Branch, bool>> filter);

        Task AddAsync(Branch branch);
        Task AddRangeAsync(List<Branch> branches);

        Task UpdateAsync(Branch branch);
        Task UpdateRangeAsync(List<Branch> branches);

        Task DeleteAsync(Branch branch);
        Task DeleteRangeAsync(List<Branch> branches);
    }
}
