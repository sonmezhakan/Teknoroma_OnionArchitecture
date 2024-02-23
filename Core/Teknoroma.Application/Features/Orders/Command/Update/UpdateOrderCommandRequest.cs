﻿using MediatR;
using Teknoroma.Domain.Enums;

namespace Teknoroma.Application.Features.Orders.Command.Update
{
	public class UpdateOrderCommandRequest:IRequest<Unit>
	{
		public Guid ID { get; set; }
		public Guid BranchID { get; set; }
		public Guid EmployeeID { get; set; }
		public Guid CustomerID { get; set; }
		public DateTime OrderDate { get; set; }

		public Guid ProductId { get; set; }
		public decimal UnitPrice { get; set; }
		public int Quantity { get; set; }
		public OrderStatu OrderStatu { get; set; }
	}
}
