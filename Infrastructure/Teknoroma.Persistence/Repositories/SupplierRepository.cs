using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;
using Teknoroma.Persistence.Context;

namespace Teknoroma.Persistence.Repositories
{
    public class SupplierRepository : BaseRepository<Supplier>, ISupplierRepository
    {
        private readonly TeknoromaContext _context;

        public SupplierRepository(TeknoromaContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IQueryable<Supplier>> GetAllSelectIdAndNameAsync()
        {
            IQueryable<Supplier> query = _context.Suppliers.Where(x => x.IsActive).Select(x => new Supplier
            {
                ID = x.ID,
                CompanyName = x.CompanyName
            });
            return query;
        }
    }
}
