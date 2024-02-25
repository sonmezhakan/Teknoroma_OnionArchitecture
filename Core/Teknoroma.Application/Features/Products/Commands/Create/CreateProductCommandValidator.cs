using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Features.Brands.Command.Create;
using Teknoroma.Application.Features.Brands.Contants;
using Teknoroma.Application.Features.Products.Constants;

namespace Teknoroma.Application.Features.Products.Command.Create
{
	public class CreateProductCommandValidator:AbstractValidator<CreateProductCommandRequest>
	{
        public CreateProductCommandValidator()
        {
			RuleFor(x => x.ProductName).NotEmpty().WithMessage(ProductsMessages.ProductNameNotNull)
					.MaximumLength(128).WithMessage(ProductsMessages.ProductNameMaxLenght);

			RuleFor(x => x.Description).MaximumLength(255).WithMessage(ProductsMessages.DescriptionMaxLenght);
		}
	}
}
