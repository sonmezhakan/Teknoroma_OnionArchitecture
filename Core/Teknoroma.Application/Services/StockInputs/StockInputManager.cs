using System.Linq.Expressions;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Services.StockInputs
{
    public class StockInputManager : IStockInputService
    {
        private readonly IStockInputRepository _stockInputRepository;

        public StockInputManager(IStockInputRepository stockInputRepository)
        {
            _stockInputRepository = stockInputRepository;
        }
        public async Task AddAsync(StockInput stockInput)
        {
            await _stockInputRepository.AddAsync(stockInput);
        }

        public async Task AddRangeAsync(List<StockInput> stockInputs)
        {
            await _stockInputRepository.AddRangeAsync(stockInputs);
        }

        public async Task<bool> AnyAsync(Expression<Func<StockInput, bool>> filter)
        {
            var result = await _stockInputRepository.AnyAsync(filter);

            return result;
        }

        public async Task DeleteAsync(StockInput stockInput)
        {
            await _stockInputRepository.DeleteAsync(stockInput);
        }

        public async Task DeleteRangeAsync(List<StockInput> stockInputs)
        {
            await _stockInputRepository.DeleteRangeAsync(stockInputs);
        }

        public async Task<IQueryable<StockInput>> GetAllAsync(Expression<Func<StockInput, bool>> filter = null)
        {
            var result = await _stockInputRepository.GetAllAsync(filter);

            return result;
        }

        public async Task<StockInput> GetAsync(Expression<Func<StockInput, bool>> filter)
        {
            var result = await _stockInputRepository.GetAsync(filter);

            return result;
        }

        public async Task UpdateAsync(StockInput stockInput)
        {
            await _stockInputRepository.UpdateAsync(stockInput);
        }

        public async Task UpdateRangeAsync(List<StockInput> stockInputs)
        {
            await _stockInputRepository.UpdateRangeAsync(stockInputs);
        }
    }
}
