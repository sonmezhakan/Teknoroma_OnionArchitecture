using System.Linq.Expressions;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Services.Stocks
{
    public class StockManager : IStockService
    {
        private readonly IStockRepository _stockRepository;

        public StockManager(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }
        public async Task AddAsync(Stock stock)
        {
            await _stockRepository.AddAsync(stock);
        }

        public async Task AddRangeAsync(List<Stock> stocks)
        {
            await _stockRepository.AddRangeAsync(stocks);
        }

        public async Task<bool> AnyAsync(Expression<Func<Stock, bool>> filter)
        {
            var result = await _stockRepository.AnyAsync(filter);

            return result;
        }

        public async Task DeleteAsync(Stock stock)
        {
            await _stockRepository.DeleteAsync(stock);
        }

        public async Task DeleteRangeAsync(List<Stock> stocks)
        {
            await _stockRepository.DeleteRangeAsync(stocks);
        }

        public async Task<IQueryable<Stock>> GetAllAsync(Expression<Func<Stock, bool>> filter = null)
        {
            var result = await _stockRepository.GetAllAsync(filter);

            return result;
        }

        public async Task<Stock> GetAsync(Expression<Func<Stock, bool>> filter)
        {
            var result = await _stockRepository.GetAsync(filter);

            return result;
        }

        public async Task UpdateAsync(Stock stock)
        {
            await _stockRepository.UpdateAsync(stock);
        }

        public async Task UpdateRangeAsync(List<Stock> stocks)
        {
            await _stockRepository.UpdateRangeAsync(stocks);
        }
    }
}
