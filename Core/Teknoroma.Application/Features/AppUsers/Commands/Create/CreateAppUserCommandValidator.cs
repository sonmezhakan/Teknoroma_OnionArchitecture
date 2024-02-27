using FluentValidation;
using Teknoroma.Application.Features.AppUsers.Contants;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.AppUsers.Command.Create
{
    public class CreateAppUserCommandValidator:AbstractValidator<AppUser>
    {
        public CreateAppUserCommandValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage(AppUsersMessages.UserNameNotNull)
                .MaximumLength(64).WithMessage(AppUsersMessages.UserNameMaxLenght);

            RuleFor(x => x.Email).NotEmpty().WithMessage(AppUsersMessages.EmailNotNull)
                .MaximumLength(128).WithMessage(AppUsersMessages.EmailMaxLenght);

            RuleFor(x => x.PhoneNumber).Must(BeNumeric).WithMessage(AppUsersMessages.PhoneNumberError)
                .NotNull().WithMessage(AppUsersMessages.PhoneNumberNotNull)
                .MaximumLength(11).WithMessage(AppUsersMessages.PhoneNumberMaxLenght);
        }

        protected bool BeNumeric(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
                return true;

            return int.TryParse(phoneNumber, out _);
        }
    }
}
