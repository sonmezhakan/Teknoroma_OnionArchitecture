using System.Linq.Expressions;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Services.ExpenseServices
{
	public interface IExpenseService
	{
		Task<IQueryable<Expense>> GetAllAsync(Expression<Func<Expense, bool>> filter = null);
		Task<Expense> GetAsync(Expression<Func<Expense, bool>> filter);

		Task<bool> AnyAsync(Expression<Func<Expense, bool>> filter);

		Task AddAsync(Expense expense);
		Task AddRangeAsync(List<Expense> expenses);

		Task UpdateAsync(Expense expense);
		Task UpdateRangeAsync(List<Expense> expenses);

		Task DeleteAsync(Expense expense);
		Task DeleteRangeAsync(List<Expense> expenses);
	}
}
