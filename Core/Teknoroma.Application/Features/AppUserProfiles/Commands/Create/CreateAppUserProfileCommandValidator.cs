using FluentValidation;
using Teknoroma.Application.Features.AppUserProfiles.Contants;

namespace Teknoroma.Application.Features.AppUserProfiles.Command.Create
{
    public class CreateAppUserProfileCommandValidator:AbstractValidator<CreateAppUserProfileCommandRequest>
    {
        public CreateAppUserProfileCommandValidator()
        {
            RuleFor(x => x.ID).NotEmpty().WithMessage(AppUserProfilesMessages.IDNotNull);

            RuleFor(x => x.FirstName).NotEmpty().WithMessage(AppUserProfilesMessages.FirstNameNotNull)
                .MaximumLength(64).WithMessage(AppUserProfilesMessages.FirstNameMaxLenght);

            RuleFor(x => x.LastName).NotEmpty().WithMessage(AppUserProfilesMessages.LastNameNotNull)
                .MaximumLength(64).WithMessage(AppUserProfilesMessages.LastNameMaxLenght);
        }
    }
}
