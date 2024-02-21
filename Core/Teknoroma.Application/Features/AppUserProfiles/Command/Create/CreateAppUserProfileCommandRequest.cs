using MediatR;

namespace Teknoroma.Application.Features.AppUserProfiles.Command.Create
{
    public class CreateAppUserProfileCommandRequest:IRequest<Unit>
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
