using FluentValidation;
using Teknoroma.Application.Features.AppUserProfiles.Contants;

namespace Teknoroma.Application.Features.AppUserProfiles.Command.Delete
{
    public class DeleteAppUserProfileCommandValidator:AbstractValidator<DeleteAppUserProfileCommandRequest>
    {
        public DeleteAppUserProfileCommandValidator()
        {
            RuleFor(x=>x.ID).NotEmpty().WithMessage(AppUserProfilesMessages.IDNotNull);
        }
    }
}
