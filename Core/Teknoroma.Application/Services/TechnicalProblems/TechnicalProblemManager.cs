using System.Linq.Expressions;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Services.TechnicalProblems
{
    public class TechnicalProblemManager : ITechnicalProblemService
    {
        private readonly ITechnicalProblemRepository _technicalProblemRepository;

        public TechnicalProblemManager(ITechnicalProblemRepository technicalProblemRepository)
        {
            _technicalProblemRepository = technicalProblemRepository;
        }
        public async Task AddAsync(TechnicalProblem technicalProblem)
        {
            await _technicalProblemRepository.AddAsync(technicalProblem);
        }

        public async Task AddRangeAsync(List<TechnicalProblem> technicalProblems)
        {
            await _technicalProblemRepository.AddRangeAsync(technicalProblems);
        }

        public async Task<bool> AnyAsync(Expression<Func<TechnicalProblem, bool>> filter)
        {
            var result = await _technicalProblemRepository.AnyAsync(filter);

            return result;
        }

        public async Task DeleteAsync(TechnicalProblem technicalProblem)
        {
            await _technicalProblemRepository.DeleteAsync(technicalProblem);
        }

        public async Task DeleteRangeAsync(List<TechnicalProblem> technicalProblems)
        {
            await _technicalProblemRepository.DeleteRangeAsync(technicalProblems);
        }

        public async Task<IQueryable<TechnicalProblem>> GetAllAsync(Expression<Func<TechnicalProblem, bool>> filter = null)
        {
            var result = await _technicalProblemRepository.GetAllAsync(filter);

            return result;
        }

        public async Task<TechnicalProblem> GetAsync(Expression<Func<TechnicalProblem, bool>> filter)
        {
            var result = await _technicalProblemRepository.GetAsync(filter);

            return result;
        }

        public async Task UpdateAsync(TechnicalProblem technicalProblem)
        {
            await _technicalProblemRepository.UpdateAsync(technicalProblem);
        }

        public async Task UpdateRangeAsync(List<TechnicalProblem> technicalProblems)
        {
            await _technicalProblemRepository.UpdateRangeAsync(technicalProblems);
        }
    }
}
