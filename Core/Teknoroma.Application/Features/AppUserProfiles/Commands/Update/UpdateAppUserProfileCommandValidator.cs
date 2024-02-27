using FluentValidation;
using Teknoroma.Application.Features.AppUserProfiles.Contants;

namespace Teknoroma.Application.Features.AppUserProfiles.Command.Update
{
    public class UpdateAppUserProfileCommandValidator:AbstractValidator<UpdateAppUserProfileCommandRequest>
    {
        public UpdateAppUserProfileCommandValidator()
        {
            RuleFor(x => x.ID).NotEmpty().WithMessage(AppUserProfilesMessages.IDNotNull);

            RuleFor(x => x.FirstName).NotEmpty().WithMessage(AppUserProfilesMessages.FirstNameNotNull)
                .MaximumLength(64).WithMessage(AppUserProfilesMessages.FirstNameMaxLenght);

            RuleFor(x => x.LastName).NotEmpty().WithMessage(AppUserProfilesMessages.LastNameNotNull)
                .MaximumLength(64).WithMessage(AppUserProfilesMessages.LastNameMaxLenght);

            RuleFor(x => x.NationalityNumber).MaximumLength(32).WithMessage(AppUserProfilesMessages.NationalityNumberMaxLenght);

            RuleFor(x => x.Address).MaximumLength(255).WithMessage(AppUserProfilesMessages.AddressMaxLenght);
        }
    }
}
