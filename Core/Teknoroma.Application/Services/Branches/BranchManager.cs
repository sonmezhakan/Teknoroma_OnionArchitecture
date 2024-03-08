using System.Linq.Expressions;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Services.Branches
{
    public class BranchManager : IBranchService
    {
        private readonly IBranchRepository _branchRepository;

        public BranchManager(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }
        public async Task AddAsync(Branch branch)
        {
           await _branchRepository.AddAsync(branch);
        }

        public async Task AddRangeAsync(List<Branch> branches)
        {
            await _branchRepository.AddRangeAsync(branches);
        }

        public async Task<bool> AnyAsync(Expression<Func<Branch, bool>> filter)
        {
            var result = await _branchRepository.AnyAsync(filter);

            return result;
        }

        public async Task DeleteAsync(Branch branch)
        {
            await _branchRepository.DeleteAsync(branch);
        }

        public async Task DeleteRangeAsync(List<Branch> branches)
        {
            await _branchRepository.DeleteRangeAsync(branches);
        }

        public async Task<IQueryable<Branch>> GetAllAsync(Expression<Func<Branch, bool>> filter = null)
        {
            var result = await _branchRepository.GetAllAsync(filter);

            return result;
        }

        public async Task<Branch> GetAsync(Expression<Func<Branch, bool>> filter)
        {
            var result = await _branchRepository.GetAsync(filter);

            return result;
        }

        public async Task UpdateAsync(Branch branch)
        {
            await _branchRepository.UpdateAsync(branch);
        }

        public async Task UpdateRangeAsync(List<Branch> branches)
        {
            await _branchRepository.UpdateRangeAsync(branches);
        }
    }
}
