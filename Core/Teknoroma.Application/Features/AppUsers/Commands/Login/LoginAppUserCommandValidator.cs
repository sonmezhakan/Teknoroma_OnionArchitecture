using FluentValidation;

namespace Teknoroma.Application.Features.AppUsers.Commands.Login
{
	public class LoginAppUserCommandValidator:AbstractValidator<LoginAppUserCommandRequest>
	{
        public LoginAppUserCommandValidator()
        {
            
        }
    }
}
