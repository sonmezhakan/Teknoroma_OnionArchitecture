using MediatR;

namespace Teknoroma.Application.Features.Employees.Command.Update
{
	public class UpdateEmployeeCommandRequest:IRequest<Unit>
	{
        public Guid ID { get; set; }
		public Guid BranchID { get; set; }
		public Guid DepartmentID { get; set; }
	}
}
