using FluentValidation;
using Teknoroma.Application.Features.AppUserRoles.Contants;

namespace Teknoroma.Application.Features.AppUserRoles.Command.Delete
{
    public class DeleteAppUserRoleCommandValidator:AbstractValidator<DeleteAppUserRoleCommandRequest>
    {
        public DeleteAppUserRoleCommandValidator()
        {
            RuleFor(x => x.ID).NotEmpty().WithMessage(AppUserRolesMessages.IDNotNull);
        }
    }
}
