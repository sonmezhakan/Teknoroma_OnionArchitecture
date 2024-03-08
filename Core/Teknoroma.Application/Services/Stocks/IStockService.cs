using System.Linq.Expressions;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Services.Stocks
{
    public interface IStockService
    {
        Task<IQueryable<Stock>> GetAllAsync(Expression<Func<Stock, bool>> filter = null);
        Task<Stock> GetAsync(Expression<Func<Stock, bool>> filter);

        Task<bool> AnyAsync(Expression<Func<Stock, bool>> filter);

        Task AddAsync(Stock stock);
        Task AddRangeAsync(List<Stock> stocks);

        Task UpdateAsync(Stock stock);
        Task UpdateRangeAsync(List<Stock> stocks);

        Task DeleteAsync(Stock stock);
        Task DeleteRangeAsync(List<Stock> stocks);
    }
}
