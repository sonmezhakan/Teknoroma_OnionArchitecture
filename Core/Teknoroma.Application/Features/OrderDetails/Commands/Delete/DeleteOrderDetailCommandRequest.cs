using MediatR;

namespace Teknoroma.Application.Features.OrderDetails.Command.Delete
{
	public class DeleteOrderDetailCommandRequest:IRequest<Unit>
	{
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public Guid BranchId { get; set; }
    }
}
