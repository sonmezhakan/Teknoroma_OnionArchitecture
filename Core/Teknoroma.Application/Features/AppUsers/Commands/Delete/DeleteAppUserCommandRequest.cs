using MediatR;
using Teknoroma.Application.Pipelines.Transaction;

namespace Teknoroma.Application.Features.AppUsers.Command.Delete
{
    public class DeleteAppUserCommandRequest:IRequest<Unit>, ITransactionalRequest
	{
        public Guid ID { get; set; }
    }
}
