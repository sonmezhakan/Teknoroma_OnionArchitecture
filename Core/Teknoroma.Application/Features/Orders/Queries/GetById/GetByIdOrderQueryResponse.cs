using Teknoroma.Domain.Enums;

namespace Teknoroma.Application.Features.Orders.Queries.GetById
{
	public class GetByIdOrderQueryResponse
	{
		public Guid ID { get; set; }
		public Guid BranchID { get; set; }
		public Guid EmployeeID { get; set; }
		public Guid CustomerID { get; set; }
		public DateTime OrderDate { get; set; }

		public OrderStatu OrderStatu { get; set; }
	}
}
