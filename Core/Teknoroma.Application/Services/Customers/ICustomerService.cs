using System.Linq.Expressions;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Services.Customers
{
    public interface ICustomerService
    {
        Task<IQueryable<Customer>> GetAllAsync(Expression<Func<Customer, bool>> filter = null);
        Task<Customer> GetAsync(Expression<Func<Customer, bool>> filter);

        Task<bool> AnyAsync(Expression<Func<Customer, bool>> filter);

        Task AddAsync(Customer customer);
        Task AddRangeAsync(List<Customer> customers);

        Task UpdateAsync(Customer customer);
        Task UpdateRangeAsync(List<Customer> customers);

        Task DeleteAsync(Customer customer);
        Task DeleteRangeAsync(List<Customer> customers);
    }
}
