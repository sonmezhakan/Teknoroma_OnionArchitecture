﻿using FluentValidation;
using Teknoroma.Application.Features.Customers.Contants;

namespace Teknoroma.Application.Features.Customers.Command.Update
{
	public class UpdateCustomerCommandValidator:AbstractValidator<UpdateCustomerCommandRequest>
	{
		public UpdateCustomerCommandValidator()
		{
			RuleFor(x => x.FullName).NotEmpty().WithMessage(CustomersMessages.FullNameNotNull)
					.MaximumLength(128).WithMessage(CustomersMessages.FullNameMaxLenght);

			RuleFor(x => x.ContactName).MaximumLength(128).WithMessage(CustomersMessages.ContactNameMaxLenght);

			RuleFor(x => x.ContactTitle).MaximumLength(64).WithMessage(CustomersMessages.ContactTitleMaxLenght);

			RuleFor(x => x.PhoneNumber).Must(BeNumeric).WithMessage(CustomersMessages.PhoneNumberError)
				.MaximumLength(11).WithMessage(CustomersMessages.PhoneNumberMaxLenght);

			RuleFor(x => x.Address).MaximumLength(255).WithMessage(CustomersMessages.AddressMaxLenght);

			RuleFor(x => x.Email).MaximumLength(128).WithMessage(CustomersMessages.EmailMaxLenght);

		}
		protected bool BeNumeric(string phoneNumber)
		{
			if (string.IsNullOrEmpty(phoneNumber))
				return true;

			return Int64.TryParse(phoneNumber, out _);
		}
	}
}
