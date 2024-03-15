using MediatR;
using Teknoroma.Application.Pipelines.Transaction;

namespace Teknoroma.Application.Features.Expenses.Commands.Create
{
	public class CreateExpenseCommandRequest:IRequest<Unit>,ITransactionalRequest
	{
		public string Title { get; set; }
		public decimal Price { get; set; }
		public DateTime ExpenseDate { get; set; }
		public string? Description { get; set; }

		public Guid EmployeeId { get; set; }
	}
}
