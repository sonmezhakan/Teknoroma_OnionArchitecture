using MediatR;
using Teknoroma.Application.Pipelines.Transaction;

namespace Teknoroma.Application.Features.OrderDetails.Command.Update
{
	public class UpdateOrderDetailCommandRequest:IRequest<Unit>, ITransactionalRequest
	{
        public Guid BranchId { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
