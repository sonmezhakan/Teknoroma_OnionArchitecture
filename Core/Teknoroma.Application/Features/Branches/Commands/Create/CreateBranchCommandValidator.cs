using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Features.Branches.Constants;

namespace Teknoroma.Application.Features.Branches.Command.Create
{
	public class CreateBranchCommandValidator : AbstractValidator<CreateBranchCommandRequest>
	{
		public CreateBranchCommandValidator()
		{
			RuleFor(x => x.BranchName).NotEmpty().WithMessage(BranchesMessages.BranchNameNotNull)
				.MaximumLength(64).WithMessage(BranchesMessages.BranchNameMaxLenght);

			RuleFor(x => x.PhoneNumber).Must(BeNumeric).WithMessage(BranchesMessages.PhoneNumberError)
				.MaximumLength(11).WithMessage(BranchesMessages.PhoneNumberMaxLenght);

			RuleFor(x => x.Address).MaximumLength(255).WithMessage(BranchesMessages.AddressMaxLenght);

			RuleFor(x=>x.Description).MaximumLength(255).WithMessage(BranchesMessages.DescriptionMaxLenght);

		}

		protected bool BeNumeric(string phoneNumber)
		{
			if (string.IsNullOrEmpty(phoneNumber))
				return true;

			return Int64.TryParse(phoneNumber, out _);
		}
	}
}
