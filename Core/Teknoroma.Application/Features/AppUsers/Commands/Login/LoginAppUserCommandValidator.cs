using FluentValidation;
using Teknoroma.Application.Features.AppUsers.Contants;

namespace Teknoroma.Application.Features.AppUsers.Commands.Login
{
	public class LoginAppUserCommandValidator:AbstractValidator<LoginAppUserCommandRequest>
	{
        public LoginAppUserCommandValidator()
        {
            RuleFor(x=>x.UserName).NotEmpty().WithMessage(AppUsersMessages.UserNameNotNull);

            RuleFor(x => x.Password).NotEmpty().WithMessage(AppUsersMessages.PasswordNotNull);
        }
    }
}
