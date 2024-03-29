﻿using FluentValidation;
using Teknoroma.Application.Features.AppUsers.Contants;

namespace Teknoroma.Application.Features.AppUsers.Command.Update
{
    public class UpdateAppUserCommandValidator:AbstractValidator<UpdateAppUserCommandRequest>
    {
        public UpdateAppUserCommandValidator()
        {
            RuleFor(x=>x.ID).NotEmpty().WithMessage(AppUsersMessages.IDNotNull);

            RuleFor(x => x.UserName).NotEmpty().WithMessage(AppUsersMessages.UserNameNotNull)
                .MaximumLength(64).WithMessage(AppUsersMessages.UserNameMaxLenght);

            RuleFor(x => x.Email).NotEmpty().WithMessage(AppUsersMessages.EmailNotNull)
                .MaximumLength(128).WithMessage(AppUsersMessages.EmailMaxLenght);

            RuleFor(x => x.PhoneNumber).NotNull().WithMessage(AppUsersMessages.PhoneNumberNotNull)
                .MaximumLength(11).WithMessage(AppUsersMessages.PhoneNumberMaxLenght);
        }

        protected bool BeNumeric(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
                return true;

            return Int64.TryParse(phoneNumber, out _);
        }
    }
}
