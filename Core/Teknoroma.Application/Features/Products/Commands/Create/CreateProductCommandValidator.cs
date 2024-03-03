using FluentValidation;
using Teknoroma.Application.Features.Products.Constants;

namespace Teknoroma.Application.Features.Products.Command.Create
{
	public class CreateProductCommandValidator:AbstractValidator<CreateProductCommandRequest>
	{
        public CreateProductCommandValidator()
        {
			RuleFor(x => x.ProductName).NotEmpty().WithMessage(ProductsMessages.ProductNameNotNull)
					.MaximumLength(128).WithMessage(ProductsMessages.ProductNameMaxLenght);

			RuleFor(x => x.BarcodeCode).MaximumLength(32).WithMessage(ProductsMessages.BarcodeCodeMaxLenght);

			RuleFor(x => x.Description).MaximumLength(255).WithMessage(ProductsMessages.DescriptionMaxLenght);
		}
	}
}
