using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;
using Teknoroma.Persistence.Context;

namespace Teknoroma.Persistence.Repositories
{
	public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
	{
		private readonly TeknoromaContext _context;

		public EmployeeRepository(TeknoromaContext context) : base(context)
		{
			_context = context;
		}

		public async Task<IQueryable<Employee>> GetFullAll(Expression<Func<Employee, bool>> filter = null)
		{
			IQueryable<Employee> result = _context.Employees;

			if(filter != null) 
				result = result.Where(filter);

			return result;
		}

		public async Task<Employee> GetFullSearch(Expression<Func<Employee, bool>> filter = null)
		{
			Employee employee = await _context.Employees.FirstOrDefaultAsync(filter);

			return employee;
		}
	}
}
