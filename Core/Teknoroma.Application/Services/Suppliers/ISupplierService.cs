using System.Linq.Expressions;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Services.Suppliers
{
    public interface ISupplierService
    {
        Task<IQueryable<Supplier>> GetAllAsync(Expression<Func<Supplier, bool>> filter = null);
        Task<Supplier> GetAsync(Expression<Func<Supplier, bool>> filter);

        Task<bool> AnyAsync(Expression<Func<Supplier, bool>> filter);

        Task AddAsync(Supplier supplier);
        Task AddRangeAsync(List<Supplier> suppliers);

        Task UpdateAsync(Supplier supplier);
        Task UpdateRangeAsync(List<Supplier> suppliers);

        Task DeleteAsync(Supplier supplier);
        Task DeleteRangeAsync(List<Supplier> suppliers);
    }
}
