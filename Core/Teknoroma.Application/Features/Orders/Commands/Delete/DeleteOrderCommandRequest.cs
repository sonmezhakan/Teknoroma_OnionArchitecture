using MediatR;
using Teknoroma.Application.Pipelines.Transaction;

namespace Teknoroma.Application.Features.Orders.Command.Delete
{
	public class DeleteOrderCommandRequest:IRequest<Unit>, ITransactionalRequest
	{
        public Guid ID { get; set; }
    }
}
