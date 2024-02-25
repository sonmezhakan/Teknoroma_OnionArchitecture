using MediatR;
using Teknoroma.Application.Pipelines.Transaction;

namespace Teknoroma.Application.Features.Branches.Command.Delete
{
	public class DeleteBranchCommandRequest:IRequest<Unit>, ITransactionalRequest
	{
        public Guid ID { get; set; }
    }
}
