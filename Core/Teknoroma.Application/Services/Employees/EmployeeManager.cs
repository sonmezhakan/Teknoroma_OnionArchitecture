using System.Linq.Expressions;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Services.Employees
{
    public class EmployeeManager : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task AddAsync(Employee employee)
        {
            await _employeeRepository.AddAsync(employee);
        }

        public async Task AddRangeAsync(List<Employee> employees)
        {
            await _employeeRepository.AddRangeAsync(employees);
        }

        public async Task<bool> AnyAsync(Expression<Func<Employee, bool>> filter)
        {
            var result = await _employeeRepository.AnyAsync(filter);

            return result;
        }

        public async Task DeleteAsync(Employee employee)
        {
            await _employeeRepository.DeleteAsync(employee);
        }

        public async Task DeleteRangeAsync(List<Employee> employees)
        {
            await _employeeRepository.DeleteRangeAsync(employees);
        }

        public async Task<IQueryable<Employee>> GetAllAsync(Expression<Func<Employee, bool>> filter = null)
        {
            var result = await _employeeRepository.GetAllAsync(filter);

            return result;
        }

        public async Task<Employee> GetAsync(Expression<Func<Employee, bool>> filter)
        {
            var result = await _employeeRepository.GetAsync(filter);

            return result;
        }

        public async Task UpdateAsync(Employee employee)
        {
            await _employeeRepository.UpdateAsync(employee);
        }

        public async Task UpdateRangeAsync(List<Employee> employees)
        {
            await _employeeRepository.UpdateRangeAsync(employees);
        }
    }
}
