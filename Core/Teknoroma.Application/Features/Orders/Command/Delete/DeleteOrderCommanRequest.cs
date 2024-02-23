using MediatR;

namespace Teknoroma.Application.Features.Orders.Command.Delete
{
	public class DeleteOrderCommanRequest:IRequest<Unit>
	{
        public Guid ID { get; set; }
    }
}
