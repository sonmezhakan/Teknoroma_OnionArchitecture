using FluentValidation;
using Teknoroma.Application.Features.AppUsers.Contants;

namespace Teknoroma.Application.Features.AppUsers.Queries.GetByUserName
{
    public class GetByUserNameAppUserQueryValidator:AbstractValidator<GetByUserNameAppUserQueryRequest>
    {
        public GetByUserNameAppUserQueryValidator()
        {
            RuleFor(x=>x.UserName).NotEmpty().WithMessage(AppUsersMessages.UserNameNotNull);
        }
    }
}
