using MediatR;
using Teknoroma.Application.Pipelines.Transaction;

namespace Teknoroma.Application.Features.Employees.Command.Update
{
	public class UpdateEmployeeCommandRequest:IRequest<Unit>, ITransactionalRequest
	{
        public Guid ID { get; set; }
		public Guid BranchID { get; set; }
		public Guid DepartmentID { get; set; }
	}
}
