using MediatR;
using Teknoroma.Application.Pipelines.Transaction;

namespace Teknoroma.Application.Features.Expenses.Commands.Update
{
	public class UpdateExpenseCommandRequest:IRequest<Unit>,ITransactionalRequest
	{
        public Guid ID { get; set; }
        public string Title { get; set; }
		public decimal Price { get; set; }
		public DateTime ExpenseDate { get; set; }
		public string? Description { get; set; }
	}
}
