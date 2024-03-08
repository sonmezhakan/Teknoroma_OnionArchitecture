using System.Linq.Expressions;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Services.Departments
{
    public interface IDepartmentService
    {
        Task<IQueryable<Department>> GetAllAsync(Expression<Func<Department, bool>> filter = null);
        Task<Department> GetAsync(Expression<Func<Department, bool>> filter);

        Task<bool> AnyAsync(Expression<Func<Department, bool>> filter);

        Task AddAsync(Department department);
        Task AddRangeAsync(List<Department> departments);

        Task UpdateAsync(Department department);
        Task UpdateRangeAsync(List<Department> departments);

        Task DeleteAsync(Department department);
        Task DeleteRangeAsync(List<Department> departments);
    }
}
