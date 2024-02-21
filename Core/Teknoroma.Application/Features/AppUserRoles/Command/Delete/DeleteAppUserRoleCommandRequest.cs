using MediatR;

namespace Teknoroma.Application.Features.AppUserRoles.Command.Delete
{
    public class DeleteAppUserRoleCommandRequest:IRequest<Unit>
    {
        public Guid ID { get; set; }
    }
}
