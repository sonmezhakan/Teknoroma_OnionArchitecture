using MediatR;
using Teknoroma.Application.Pipelines.Transaction;

namespace Teknoroma.Application.Features.Expenses.Commands.Delete
{
	public class DeleteExpenseCommandRequest:IRequest<Unit>,ITransactionalRequest
	{
		public Guid ID { get; set; }
	}
}
