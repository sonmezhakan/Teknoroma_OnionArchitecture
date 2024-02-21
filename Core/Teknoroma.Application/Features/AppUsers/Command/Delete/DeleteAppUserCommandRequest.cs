using MediatR;

namespace Teknoroma.Application.Features.AppUsers.Command.Delete
{
    public class DeleteAppUserCommandRequest:IRequest<Unit>
    {
        public Guid ID { get; set; }
    }
}
