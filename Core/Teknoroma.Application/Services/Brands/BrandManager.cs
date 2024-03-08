using System.Linq.Expressions;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Services.Brands
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandManager(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task AddAsync(Brand brand)
        {
            await _brandRepository.AddAsync(brand);
        }

        public async Task AddRangeAsync(List<Brand> brands)
        {
            await _brandRepository.AddRangeAsync(brands);
        }

        public async Task<bool> AnyAsync(Expression<Func<Brand, bool>> filter)
        {
            var result = await _brandRepository.AnyAsync(filter);

            return result;
        }

        public async Task DeleteAsync(Brand brand)
        {
            await _brandRepository.DeleteAsync(brand);
        }

        public async Task DeleteRangeAsync(List<Brand> brands)
        {
            await _brandRepository.DeleteRangeAsync(brands);
        }

        public async Task<IQueryable<Brand>> GetAllAsync(Expression<Func<Brand, bool>> filter = null)
        {
            var result = await _brandRepository.GetAllAsync(filter);

            return result;
        }

        public async Task<Brand> GetAsync(Expression<Func<Brand, bool>> filter)
        {
            var result = await _brandRepository.GetAsync(filter);

            return result;
        }

        public async Task UpdateAsync(Brand brand)
        {
            await _brandRepository.UpdateAsync(brand);
        }

        public async Task UpdateRangeAsync(List<Brand> brands)
        {
            await _brandRepository.UpdateRangeAsync(brands);
        }
    }
}
