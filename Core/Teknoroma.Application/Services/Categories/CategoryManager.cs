using System.Linq.Expressions;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Services.Categories
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task AddAsync(Category category)
        {
            await _categoryRepository.AddAsync(category);
        }

        public async Task AddRangeAsync(List<Category> categories)
        {
            await _categoryRepository.AddRangeAsync(categories);
        }

        public async Task<bool> AnyAsync(Expression<Func<Category, bool>> filter)
        {
            var result = await _categoryRepository.AnyAsync(filter);

            return result;
        }

        public async Task DeleteAsync(Category category)
        {
            await _categoryRepository.DeleteAsync(category);
        }

        public async Task DeleteRangeAsync(List<Category> categories)
        {
            await _categoryRepository.DeleteRangeAsync(categories);
        }

        public async Task<IQueryable<Category>> GetAllAsync(Expression<Func<Category, bool>> filter = null)
        {
            var result = await _categoryRepository.GetAllAsync(filter);

            return result;
        }

        public async Task<Category> GetAsync(Expression<Func<Category, bool>> filter)
        {
            var result = await _categoryRepository.GetAsync(filter);

            return result;
        }

        public async Task UpdateAsync(Category category)
        {
            await _categoryRepository.UpdateAsync(category);
        }

        public async Task UpdateRangeAsync(List<Category> categories)
        {
           await _categoryRepository.UpdateRangeAsync(categories);
        }
    }
}
