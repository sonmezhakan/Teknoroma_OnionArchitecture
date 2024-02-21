using MediatR;

namespace Teknoroma.Application.Features.AppUserRoles.Command.Create
{
    public class CreateAppUserRoleCommandRequest:IRequest<Unit>
    {
        public string Name { get; set; }
    }
}
