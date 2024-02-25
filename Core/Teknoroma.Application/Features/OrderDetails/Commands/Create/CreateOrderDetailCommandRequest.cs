using MediatR;
using Teknoroma.Application.Features.Orders.Models;
using Teknoroma.Application.Pipelines.Transaction;

namespace Teknoroma.Application.Features.OrderDetails.Command.Create
{
	public class CreateOrderDetailCommandRequest:IRequest<Unit>, ITransactionalRequest
	{
		public Guid ID { get; set; }

		public List<CartItem> CartItems { get; set; }
	}
}
