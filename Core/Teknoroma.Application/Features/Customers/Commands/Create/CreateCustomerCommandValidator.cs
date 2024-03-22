using FluentValidation;
using Teknoroma.Application.Features.Customers.Contants;

namespace Teknoroma.Application.Features.Customers.Command.Create
{
	public class CreateCustomerCommandValidator:AbstractValidator<CreateCustomerCommandRequest>
	{
        public CreateCustomerCommandValidator()
        {
			RuleFor(x => x.FullName).NotEmpty().WithMessage(CustomersMessages.FullNameNotNull)
					.MaximumLength(128).WithMessage(CustomersMessages.FullNameMaxLenght);

			RuleFor(x => x.ContactName).MaximumLength(128).WithMessage(CustomersMessages.ContactNameMaxLenght);

			RuleFor(x => x.ContactTitle).MaximumLength(64).WithMessage(CustomersMessages.ContactTitleMaxLenght);

			RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage(CustomersMessages.PhoneNumberNotNull)
				.Must(BeNumeric).WithMessage(CustomersMessages.PhoneNumberError)
				.MaximumLength(11).WithMessage(CustomersMessages.PhoneNumberMaxLenght);

			RuleFor(x => x.Address).MaximumLength(255).WithMessage(CustomersMessages.AddressMaxLenght);

			RuleFor(x => x.Email).MaximumLength(128).WithMessage(CustomersMessages.EmailMaxLenght);
			
		}
		protected bool BeNumeric(string phoneNumber)
		{
			return Int64.TryParse(phoneNumber, out _);
		}
	}
}
