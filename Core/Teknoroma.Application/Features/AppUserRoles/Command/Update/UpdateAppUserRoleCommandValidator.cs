using FluentValidation;
using Teknoroma.Application.Features.AppUserRoles.Contants;

namespace Teknoroma.Application.Features.AppUserRoles.Command.Update
{
    public class UpdateAppUserRoleCommandValidator:AbstractValidator<UpdateAppUserRoleCommandRequest>
    {
        public UpdateAppUserRoleCommandValidator()
        {
            RuleFor(x => x.ID).NotEmpty().WithMessage(AppUserRolesMessages.IDNotNull);

            RuleFor(x => x.Name).NotEmpty().WithMessage(AppUserRolesMessages.NameNotNull)
                .MaximumLength(256).WithMessage(AppUserRolesMessages.NameMaxLenght);
        }
    }
}
