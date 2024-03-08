using System.Linq.Expressions;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Services.Departments
{
    public class DepartmentManager : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentManager(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task AddAsync(Department department)
        {
            await _departmentRepository.AddAsync(department);
        }

        public async Task AddRangeAsync(List<Department> departments)
        {
            await _departmentRepository.AddRangeAsync(departments);
        }

        public async Task<bool> AnyAsync(Expression<Func<Department, bool>> filter)
        {
           var result = await _departmentRepository.AnyAsync(filter);

            return result;
        }

        public async Task DeleteAsync(Department department)
        {
            await _departmentRepository.DeleteAsync(department);
        }

        public async Task DeleteRangeAsync(List<Department> departments)
        {
            await _departmentRepository.DeleteRangeAsync(departments);
        }

        public async Task<IQueryable<Department>> GetAllAsync(Expression<Func<Department, bool>> filter = null)
        {
            var result = await _departmentRepository.GetAllAsync(filter);

            return result;
        }

        public async Task<Department> GetAsync(Expression<Func<Department, bool>> filter)
        {
            var result = await _departmentRepository.GetAsync(filter);

            return result;
        }

        public async Task UpdateAsync(Department department)
        {
            await _departmentRepository.UpdateAsync(department);
        }

        public async Task UpdateRangeAsync(List<Department> departments)
        {
            await _departmentRepository.UpdateRangeAsync(departments);
        }
    }
}
