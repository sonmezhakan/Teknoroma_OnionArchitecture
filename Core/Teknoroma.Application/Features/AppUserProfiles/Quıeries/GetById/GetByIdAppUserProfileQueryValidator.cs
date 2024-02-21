using FluentValidation;
using Teknoroma.Application.Features.AppUserProfiles.Contants;

namespace Teknoroma.Application.Features.AppUserProfiles.Quıeries.GetById
{
    public class GetByIdAppUserProfileQueryValidator:AbstractValidator<GetByIdAppUserProfileQueryRequest>
    {
        public GetByIdAppUserProfileQueryValidator()
        {
            RuleFor(x => x.ID).NotEmpty().WithMessage(AppUserProfilesMessages.IDNotNull);
        }
    }
}
