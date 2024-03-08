using System.Linq.Expressions;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Services.Brands
{
    public interface IBrandService
    {
        Task<IQueryable<Brand>> GetAllAsync(Expression<Func<Brand, bool>> filter = null);
        Task<Brand> GetAsync(Expression<Func<Brand, bool>> filter);

        Task<bool> AnyAsync(Expression<Func<Brand, bool>> filter);

        Task AddAsync(Brand brand);
        Task AddRangeAsync(List<Brand> brands);

        Task UpdateAsync(Brand brand);
        Task UpdateRangeAsync(List<Brand> brands);

        Task DeleteAsync(Brand brand);
        Task DeleteRangeAsync(List<Brand> brands);
    }
}
