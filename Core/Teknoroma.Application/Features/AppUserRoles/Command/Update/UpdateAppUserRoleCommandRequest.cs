using MediatR;

namespace Teknoroma.Application.Features.AppUserRoles.Command.Update
{
    public class UpdateAppUserRoleCommandRequest:IRequest<Unit>
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
    }
}
