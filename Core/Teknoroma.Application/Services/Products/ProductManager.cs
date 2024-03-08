using System.Linq.Expressions;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Services.Products
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task AddAsync(Product product)
        {
            await _productRepository.AddAsync(product);
        }

        public async Task AddRangeAsync(List<Product> products)
        {
           await _productRepository.AddRangeAsync(products);
        }

        public async Task<bool> AnyAsync(Expression<Func<Product, bool>> filter)
        {
            var result = await _productRepository.AnyAsync(filter);

            return result;
        }

        public async Task DeleteAsync(Product product)
        {
            await _productRepository.DeleteAsync(product);
        }

        public async Task DeleteRangeAsync(List<Product> product)
        {
            await _productRepository.DeleteRangeAsync(product);
        }

        public async Task<IQueryable<Product>> GetAllAsync(Expression<Func<Product, bool>> filter = null)
        {
           var result = await _productRepository.GetAllAsync(filter);

            return result;
        }

        public async Task<Product> GetAsync(Expression<Func<Product, bool>> filter)
        {
            var result = await _productRepository.GetAsync(filter);

            return result;
        }

        public async Task UpdateAsync(Product product)
        {
            await _productRepository.UpdateAsync(product);
        }

        public async Task UpdateRangeAsync(List<Product> products)
        {
           await _productRepository.UpdateRangeAsync(products);
        }
    }
}
