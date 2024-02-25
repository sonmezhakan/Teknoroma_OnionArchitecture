
using MediatR;
using Teknoroma.Application.Pipelines.Transaction;

namespace Teknoroma.Application.Features.AppUserProfiles.Command.Delete
{
    public class DeleteAppUserProfileCommandRequest:IRequest<Unit>, ITransactionalRequest
	{
        public Guid ID { get; set; }
    }
}
