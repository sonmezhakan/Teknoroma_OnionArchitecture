using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

using Teknoroma.Persistence.Context;

namespace Teknoroma.Persistence.Repositories
{
    public class BrandRepository : BaseRepository<Brand>, IBrandRepository
    {
        private readonly TeknoromaContext _context;

        public BrandRepository(TeknoromaContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IQueryable<Brand>> GetAllSelectIdAndNameAsync()
        {
            IQueryable<Brand> query = _context.Brands.Where(x => x.IsActive).Select(x => new Brand
            {
                ID = x.ID,
                BrandName = x.BrandName
            });
            return query;
        }
    }
}
