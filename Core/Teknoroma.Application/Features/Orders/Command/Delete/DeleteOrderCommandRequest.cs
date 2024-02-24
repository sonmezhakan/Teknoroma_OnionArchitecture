using MediatR;

namespace Teknoroma.Application.Features.Orders.Command.Delete
{
	public class DeleteOrderCommandRequest:IRequest<Unit>
	{
        public Guid ID { get; set; }
    }
}
