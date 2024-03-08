using System.Linq.Expressions;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Services.Categories
{
    public interface ICategoryService
    {
        Task<IQueryable<Category>> GetAllAsync(Expression<Func<Category, bool>> filter = null);
        Task<Category> GetAsync(Expression<Func<Category, bool>> filter);

        Task<bool> AnyAsync(Expression<Func<Category, bool>> filter);

        Task AddAsync(Category category);
        Task AddRangeAsync(List<Category> categories);

        Task UpdateAsync(Category category);
        Task UpdateRangeAsync(List<Category> categories);

        Task DeleteAsync(Category category);
        Task DeleteRangeAsync(List<Category> categories);
    }
}
