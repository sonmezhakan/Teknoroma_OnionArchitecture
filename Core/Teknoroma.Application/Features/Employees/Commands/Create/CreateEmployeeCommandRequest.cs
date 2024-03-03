using MediatR;
using Teknoroma.Application.Features.AppUserRoles.Models;
using Teknoroma.Application.Pipelines.Transaction;

namespace Teknoroma.Application.Features.Employees.Command.Create
{
	public class CreateEmployeeCommandRequest:IRequest<Unit>, ITransactionalRequest
	{
		public Guid ID { get; set; }
		public Guid BranchID { get; set; }
		public Guid DepartmentID { get; set; }
        public decimal? Salary { get; set; }
    }
}
