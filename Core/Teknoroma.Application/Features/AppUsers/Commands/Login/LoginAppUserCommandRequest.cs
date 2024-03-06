using MediatR;

namespace Teknoroma.Application.Features.AppUsers.Commands.Login
{
	public class LoginAppUserCommandRequest:IRequest<LoginAppUserCommandResponse>
	{
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
