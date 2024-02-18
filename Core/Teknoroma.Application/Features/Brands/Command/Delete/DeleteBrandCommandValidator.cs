using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Features.Brands.Contants;

namespace Teknoroma.Application.Features.Brands.Command.Delete
{
	public class DeleteBrandCommandValidator:AbstractValidator<DeleteBrandCommandRequest>
	{
        public DeleteBrandCommandValidator()
        {
			RuleFor(x => x.ID).NotEmpty().WithMessage(BrandsMessages.IDNotNull);
		}
    }
}
