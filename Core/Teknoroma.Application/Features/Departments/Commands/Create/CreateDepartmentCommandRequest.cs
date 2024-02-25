using MediatR;
using Teknoroma.Application.Pipelines.Transaction;

namespace Teknoroma.Application.Features.Departments.Command.Create
{
	public class CreateDepartmentCommandRequest:IRequest<Unit>, ITransactionalRequest
	{
		public string DepartmentName { get; set; }
		public string? Description { get; set; }
		
	}
}
