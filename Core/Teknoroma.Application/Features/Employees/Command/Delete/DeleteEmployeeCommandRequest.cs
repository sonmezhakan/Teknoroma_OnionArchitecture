using MediatR;

namespace Teknoroma.Application.Features.Employees.Command.Delete
{
	public class DeleteEmployeeCommandRequest:IRequest<Unit>
	{
		public Guid ID { get; set; }
	}
}
