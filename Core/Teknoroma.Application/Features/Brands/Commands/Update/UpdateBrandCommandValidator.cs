using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Features.Brands.Contants;

namespace Teknoroma.Application.Features.Brands.Command.Update
{
	public class UpdateBrandCommandValidator:AbstractValidator<UpdateBrandCommandRequest>
	{
		public UpdateBrandCommandValidator()
		{
			RuleFor(x => x.BrandName).NotEmpty().WithMessage(BrandsMessages.BrandNameNotNull)
				.MaximumLength(128).WithMessage(BrandsMessages.BrandNameMaxLenght);

			RuleFor(x => x.PhoneNumber).Must(BeNumeric).WithMessage(BrandsMessages.PhoneNumberError)
				.MaximumLength(11).WithMessage(BrandsMessages.PhoneNumberMaxLenght);

			RuleFor(x => x.Description).MaximumLength(255).WithMessage(BrandsMessages.DescriptionMaxLenght);
		}

		protected bool BeNumeric(string phoneNumber)
		{
			if (string.IsNullOrEmpty(phoneNumber))
				return true;

			return Int64.TryParse(phoneNumber, out _);
		}
	}
}
