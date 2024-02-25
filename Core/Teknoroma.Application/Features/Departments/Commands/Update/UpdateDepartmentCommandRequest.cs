using MediatR;
using Teknoroma.Application.Pipelines.Transaction;

namespace Teknoroma.Application.Features.Departments.Command.Update
{
	public class UpdateDepartmentCommandRequest:IRequest<Unit>, ITransactionalRequest
	{
		public Guid ID { get; set; }
		public string DepartmentName { get; set; }
		public string? Description { get; set; }
	}
}
