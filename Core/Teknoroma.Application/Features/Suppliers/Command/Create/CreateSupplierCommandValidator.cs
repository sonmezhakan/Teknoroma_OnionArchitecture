using FluentValidation;
using Teknoroma.Application.Features.Suppliers.Contants;

namespace Teknoroma.Application.Features.Suppliers.Command.Create
{
	public class CreateSupplierCommandValidator:AbstractValidator<CreateSupplierCommandRequest>
	{
        public CreateSupplierCommandValidator()
        {
			RuleFor(x => x.CompanyName).NotEmpty().WithMessage(SuppliersMessages.CompanyNameNotNull)
					.MaximumLength(255).WithMessage(SuppliersMessages.CompanyNameMaxLenght);

			RuleFor(x => x.ContactName).MaximumLength(128).WithMessage(SuppliersMessages.ContactNameMaxLenght);

			RuleFor(x => x.ContactTitle).MaximumLength(64).WithMessage(SuppliersMessages.ContactTitleMaxLenght);

			RuleFor(x => x.Email).MaximumLength(128).WithMessage(SuppliersMessages.EmailMaxLenght);

			RuleFor(x => x.PhoneNumber).Must(BeNumeric).WithMessage(SuppliersMessages.PhoneNumberError)
				.MaximumLength(11).WithMessage(SuppliersMessages.PhoneNumberMaxLenght);

			RuleFor(x => x.Address).MaximumLength(255).WithMessage(SuppliersMessages.AddressMaxLenght);

			RuleFor(x => x.WebSite).MaximumLength(255).WithMessage(SuppliersMessages.WebSiteMaxLenght);
		}
		protected bool BeNumeric(string phoneNumber)
		{
			if (string.IsNullOrEmpty(phoneNumber))
				return true;

			return int.TryParse(phoneNumber, out _);
		}
	}
}
