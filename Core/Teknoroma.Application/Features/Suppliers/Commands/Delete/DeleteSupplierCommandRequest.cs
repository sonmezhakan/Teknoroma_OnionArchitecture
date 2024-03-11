using MediatR;
using Teknoroma.Application.Pipelines.Transaction;

namespace Teknoroma.Application.Features.Suppliers.Command.Delete
{
	public class DeleteSupplierCommandRequest:IRequest<Unit>, ITransactionalRequest
	{
        public Guid ID { get; set; }
    }
}
