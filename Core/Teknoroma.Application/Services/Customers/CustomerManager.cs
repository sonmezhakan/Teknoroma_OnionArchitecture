using System.Linq.Expressions;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Services.Customers
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerManager(ICustomerRepository customerRepository)
        {
           _customerRepository = customerRepository;
        }
        public async Task AddAsync(Customer customer)
        {
           await _customerRepository.AddAsync(customer);
        }

        public async Task AddRangeAsync(List<Customer> customers)
        {
            await _customerRepository.AddRangeAsync(customers);
        }

        public async Task<bool> AnyAsync(Expression<Func<Customer, bool>> filter)
        {
            var result = await _customerRepository.AnyAsync(filter);

            return result;
        }

        public async Task DeleteAsync(Customer customer)
        {
            await _customerRepository.DeleteAsync(customer);
        }

        public async Task DeleteRangeAsync(List<Customer> customers)
        {
            await _customerRepository.DeleteRangeAsync(customers);
        }

        public async Task<IQueryable<Customer>> GetAllAsync(Expression<Func<Customer, bool>> filter = null)
        {
            var result = await _customerRepository.GetAllAsync(filter);

            return result;
        }

        public async Task<Customer> GetAsync(Expression<Func<Customer, bool>> filter)
        {
            var result = await _customerRepository.GetAsync(filter);

            return result;
        }

        public async Task UpdateAsync(Customer customer)
        {
            await _customerRepository.UpdateAsync(customer);
        }

        public async Task UpdateRangeAsync(List<Customer> customers)
        {
            await _customerRepository.UpdateRangeAsync(customers);
        }
    }
}
