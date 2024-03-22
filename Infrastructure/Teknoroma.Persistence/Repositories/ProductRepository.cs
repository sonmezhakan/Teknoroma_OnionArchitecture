using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;
using Teknoroma.Persistence.Context;

namespace Teknoroma.Persistence.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly TeknoromaContext _context;

        public ProductRepository(TeknoromaContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IQueryable<Product>> GetAllSelectIdAndNameAsync()
        {
            IQueryable<Product> query = _context.Products.Where(x => x.IsActive).Select(x => new Product
            {
                ID = x.ID,
                ProductName = x.ProductName
            });
            return query;
        }
    }
}
