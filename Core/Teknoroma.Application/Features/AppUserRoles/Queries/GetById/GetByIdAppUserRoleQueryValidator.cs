using FluentValidation;
using Teknoroma.Application.Features.AppUserRoles.Contants;

namespace Teknoroma.Application.Features.AppUserRoles.Queries.GetById
{
    public class GetByIdAppUserRoleQueryValidator:AbstractValidator<GetByIdAppUserRoleQueryRequest>
    {
        public GetByIdAppUserRoleQueryValidator()
        {
            RuleFor(x => x.ID).NotEmpty().WithMessage(AppUserRolesMessages.IDNotNull);
        }
    }
}
