using MediatR;
using Teknoroma.Application.Pipelines.Transaction;

namespace Teknoroma.Application.Features.Employees.Command.Delete
{
	public class DeleteEmployeeCommandRequest:IRequest<Unit>, ITransactionalRequest
	{
		public Guid ID { get; set; }
	}
}
