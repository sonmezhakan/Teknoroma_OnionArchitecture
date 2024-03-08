using System.Linq.Expressions;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Services.StockInputs
{
    public interface IStockInputService
    {
        Task<IQueryable<StockInput>> GetAllAsync(Expression<Func<StockInput, bool>> filter = null);
        Task<StockInput> GetAsync(Expression<Func<StockInput, bool>> filter);

        Task<bool> AnyAsync(Expression<Func<StockInput, bool>> filter);

        Task AddAsync(StockInput stockInput);
        Task AddRangeAsync(List<StockInput> stockInputs);

        Task UpdateAsync(StockInput stockInput);
        Task UpdateRangeAsync(List<StockInput> stockInputs);

        Task DeleteAsync(StockInput stockInput);
        Task DeleteRangeAsync(List<StockInput> stockInputs);
    }
}
