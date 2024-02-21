using MediatR;

namespace Teknoroma.Application.Features.Employees.Command.Create
{
	public class CreateEmployeeCommandRequest:IRequest<Unit>
	{
		public Guid ID { get; set; }
		public Guid BranchID { get; set; }
		public Guid DepartmentID { get; set; }
	}
}
