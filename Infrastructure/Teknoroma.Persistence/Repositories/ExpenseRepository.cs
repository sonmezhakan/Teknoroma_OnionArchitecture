using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;
using Teknoroma.Persistence.Context;

namespace Teknoroma.Persistence.Repositories
{
	public class ExpenseRepository : BaseRepository<Expense>, IExpenseRepository
	{
		public ExpenseRepository(TeknoromaContext context) : base(context)
		{
		}
	}
}
