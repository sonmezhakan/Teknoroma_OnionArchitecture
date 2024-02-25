using System.Linq.Expressions;
using Teknoroma.Domain.Interfaces;

namespace Teknoroma.Application.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class, IEntity
    {
        Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter);

        Task AddAsync(TEntity entity);
        Task AddRangeAsync(List<TEntity> entities);

        Task UpdateAsync(TEntity entity);
        Task UpdateRangeAsync(List<TEntity> entities);

        Task DeleteAsync(TEntity entity);
        Task DeleteRangeAsync(List<TEntity> entities);


	}
}
