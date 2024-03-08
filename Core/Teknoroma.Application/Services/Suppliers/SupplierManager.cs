using System.Linq.Expressions;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Services.Suppliers
{
    public class SupplierManager : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierManager(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }
        public async Task AddAsync(Supplier supplier)
        {
            await _supplierRepository.AddAsync(supplier);
        }

        public async Task AddRangeAsync(List<Supplier> suppliers)
        {
            await _supplierRepository.AddRangeAsync(suppliers);
        }

        public async Task<bool> AnyAsync(Expression<Func<Supplier, bool>> filter)
        {
            var result = await _supplierRepository.AnyAsync(filter);

            return result;
        }

        public async Task DeleteAsync(Supplier supplier)
        {
            await _supplierRepository.DeleteAsync(supplier);
        }

        public async Task DeleteRangeAsync(List<Supplier> suppliers)
        {
            await _supplierRepository.DeleteRangeAsync(suppliers);
        }

        public async Task<IQueryable<Supplier>> GetAllAsync(Expression<Func<Supplier, bool>> filter = null)
        {
            var result = await _supplierRepository.GetAllAsync(filter);

            return result;
        }

        public async Task<Supplier> GetAsync(Expression<Func<Supplier, bool>> filter)
        {
            var result = await _supplierRepository.GetAsync(filter);

            return result;
        }

        public async Task UpdateAsync(Supplier supplier)
        {
            await _supplierRepository.UpdateAsync(supplier);
        }

        public async Task UpdateRangeAsync(List<Supplier> suppliers)
        {
            await _supplierRepository.UpdateRangeAsync(suppliers);
        }
    }
}
