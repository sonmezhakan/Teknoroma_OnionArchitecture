using MediatR;
using Teknoroma.Application.Pipelines.Transaction;

namespace Teknoroma.Application.Features.AppUserRoles.Command.Update
{
    public class UpdateAppUserRoleCommandRequest:IRequest<Unit>, ITransactionalRequest
	{
        public Guid ID { get; set; }
        public string Name { get; set; }
    }
}
