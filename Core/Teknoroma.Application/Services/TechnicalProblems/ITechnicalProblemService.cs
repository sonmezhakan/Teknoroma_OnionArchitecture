using System.Linq.Expressions;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Services.TechnicalProblems
{
    public interface ITechnicalProblemService
    {
        Task<IQueryable<TechnicalProblem>> GetAllAsync(Expression<Func<TechnicalProblem, bool>> filter = null);
        Task<TechnicalProblem> GetAsync(Expression<Func<TechnicalProblem, bool>> filter);

        Task<bool> AnyAsync(Expression<Func<TechnicalProblem, bool>> filter);

        Task AddAsync(TechnicalProblem technicalProblem);
        Task AddRangeAsync(List<TechnicalProblem> technicalProblems);

        Task UpdateAsync(TechnicalProblem technicalProblem);
        Task UpdateRangeAsync(List<TechnicalProblem> technicalProblems);

        Task DeleteAsync(TechnicalProblem technicalProblem);
        Task DeleteRangeAsync(List<TechnicalProblem> technicalProblems);
    }
}
