using FluentValidation;
using Teknoroma.Application.Features.AppUsers.Contants;

namespace Teknoroma.Application.Features.AppUsers.Queries.GetById
{
    public class GetByIdAppUserQueryValidator:AbstractValidator<GetByIdAppUserQueryRequest>
    {
        public GetByIdAppUserQueryValidator()
        {
            RuleFor(x => x.ID).NotEmpty().WithMessage(AppUsersMessages.IDNotNull);
        }
    }
}
