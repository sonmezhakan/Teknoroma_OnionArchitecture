using System.Linq.Expressions;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Services.Products
{
    public interface IProductService
    {
        Task<IQueryable<Product>> GetAllAsync(Expression<Func<Product, bool>> filter = null);
        Task<Product> GetAsync(Expression<Func<Product, bool>> filter);

        Task<bool> AnyAsync(Expression<Func<Product, bool>> filter);

        Task AddAsync(Product product);
        Task AddRangeAsync(List<Product> products);

        Task UpdateAsync(Product product);
        Task UpdateRangeAsync(List<Product> products);

        Task DeleteAsync(Product product);
        Task DeleteRangeAsync(List<Product> product);
    }
}
