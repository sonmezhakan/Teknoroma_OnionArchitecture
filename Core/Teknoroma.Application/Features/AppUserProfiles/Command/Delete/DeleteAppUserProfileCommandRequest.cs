
using MediatR;

namespace Teknoroma.Application.Features.AppUserProfiles.Command.Delete
{
    public class DeleteAppUserProfileCommandRequest:IRequest<Unit>
    {
        public Guid ID { get; set; }
    }
}
