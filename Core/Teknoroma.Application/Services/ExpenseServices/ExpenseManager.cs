using System.Linq.Expressions;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Services.ExpenseServices
{
	public class ExpenseManager : IExpenseService
	{
		private readonly IExpenseRepository _expenseRepository;

		public ExpenseManager(IExpenseRepository expenseRepository)
        {
			_expenseRepository = expenseRepository;
		}
        public async Task AddAsync(Expense expense)
		{
			await _expenseRepository.AddAsync(expense);
		}

		public async Task AddRangeAsync(List<Expense> expenses)
		{
			await _expenseRepository.AddRangeAsync(expenses);
		}

		public async Task<bool> AnyAsync(Expression<Func<Expense, bool>> filter)
		{
			var result = await _expenseRepository.AnyAsync(filter);

			return result;
		}

		public async Task DeleteAsync(Expense expense)
		{
			await _expenseRepository.DeleteAsync(expense);
		}

		public async Task DeleteRangeAsync(List<Expense> expenses)
		{
			await _expenseRepository.DeleteRangeAsync(expenses);
		}

		public async Task<IQueryable<Expense>> GetAllAsync(Expression<Func<Expense, bool>> filter = null)
		{
			var result = await _expenseRepository.GetAllAsync(filter);

			return result;
		}

		public async Task<Expense> GetAsync(Expression<Func<Expense, bool>> filter)
		{
			var result = await _expenseRepository.GetAsync(filter);

			return result;
		}

		public async Task UpdateAsync(Expense expense)
		{
			await _expenseRepository.UpdateAsync(expense);
		}

		public async Task UpdateRangeAsync(List<Expense> expenses)
		{
			await _expenseRepository.UpdateRangeAsync(expenses);
		}
	}
}
