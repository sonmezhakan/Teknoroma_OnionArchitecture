using MediatR;
using Teknoroma.Application.Pipelines.Transaction;

namespace Teknoroma.Application.Features.Departments.Command.Delete
{
	public class DeleteDepartmentCommandRequest:IRequest<Unit>, ITransactionalRequest
	{
		public Guid ID { get; set; }
	}
}
