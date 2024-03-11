using MediatR;
using Teknoroma.Application.Pipelines.Transaction;
using Teknoroma.Domain.Enums;

namespace Teknoroma.Application.Features.Orders.Command.Update
{
	public class UpdateOrderCommandRequest:IRequest<Unit>, ITransactionalRequest
	{
		public Guid ID { get; set; }
		public Guid BranchID { get; set; }
		public Guid EmployeeID { get; set; }
		public Guid CustomerID { get; set; }
		public DateTime OrderDate { get; set; }

		public OrderStatu OrderStatu { get; set; }
	}
}
