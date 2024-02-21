using MediatR;

namespace Teknoroma.Application.Features.AppUsers.Command.Create
{
    public class CreateAppUserCommandRequest:IRequest<Unit>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
