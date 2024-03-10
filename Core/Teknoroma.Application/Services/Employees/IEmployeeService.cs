using System.Linq.Expressions;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Services.Employees
{
    public interface IEmployeeService
    {
        Task<IQueryable<Employee>> GetAllAsync(Expression<Func<Employee, bool>> filter = null);
        Task<Employee> GetAsync(Expression<Func<Employee, bool>> filter);
        Task<IQueryable<Employee>> GetFullAll(Expression<Func<Employee, bool>> filter = null);
		Task<Employee> GetFullSearch(Expression<Func<Employee, bool>> filter);

		Task<bool> AnyAsync(Expression<Func<Employee, bool>> filter);

        Task AddAsync(Employee employee);
        Task AddRangeAsync(List<Employee> employees);

        Task UpdateAsync(Employee employee);
        Task UpdateRangeAsync(List<Employee> employees);

        Task DeleteAsync(Employee employee);
        Task DeleteRangeAsync(List<Employee> employees);
    }
}

