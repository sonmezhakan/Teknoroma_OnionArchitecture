using FluentValidation;
using Teknoroma.Application.Features.AppUserRoles.Contants;

namespace Teknoroma.Application.Features.AppUserRoles.Command.Create
{
    public class CreateAppUserRoleCommandValidator:AbstractValidator<CreateAppUserRoleCommandRequest>
    {
        public CreateAppUserRoleCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(AppUserRolesMessages.NameNotNull)
                .MaximumLength(256).WithMessage(AppUserRolesMessages.NameMaxLenght);
        }
    }
}
