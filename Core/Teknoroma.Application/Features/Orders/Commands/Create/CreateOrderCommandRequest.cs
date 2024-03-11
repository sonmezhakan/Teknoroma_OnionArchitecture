using MediatR;
using Teknoroma.Application.Features.Orders.Models;
using Teknoroma.Application.Pipelines.Transaction;
using Teknoroma.Domain.Enums;

namespace Teknoroma.Application.Features.Orders.Command.Create
{
    public class CreateOrderCommandRequest:IRequest<Unit>, ITransactionalRequest
	{
		public List<CartItem> CartItems { get; set; }

		public Guid BranchId { get; set; }
		public Guid EmployeeId { get; set; }
		public Guid CustomerId { get; set; }
		public DateTime OrderDate { get; set; }

		public OrderStatu OrderStatu { get; set; }

        
    }
}
