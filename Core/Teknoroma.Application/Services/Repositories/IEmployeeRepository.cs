using System.Linq.Expressions;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Services.Repositories
{
	public interface IEmployeeRepository : IBaseRepository<Employee>
	{
        Task<IQueryable<Employee>> GetFullAll(Expression<Func<Employee, bool>> filter = null);
		Task<Employee> GetFullSearch(Expression<Func<Employee, bool>> filter = null);
    }
}
