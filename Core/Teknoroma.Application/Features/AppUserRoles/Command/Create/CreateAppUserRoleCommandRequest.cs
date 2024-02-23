using MediatR;
using Teknoroma.Application.Pipelines.Transaction;

namespace Teknoroma.Application.Features.AppUserRoles.Command.Create
{
    public class CreateAppUserRoleCommandRequest:IRequest<Unit>, ITransactionalRequest
    {
        public string Name { get; set; }
    }
}
