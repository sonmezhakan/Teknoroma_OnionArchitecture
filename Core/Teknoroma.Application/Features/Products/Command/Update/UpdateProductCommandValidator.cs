using FluentValidation;
using Teknoroma.Application.Features.Products.Constants;

namespace Teknoroma.Application.Features.Products.Command.Update
{
	public class UpdateProductCommandValidator:AbstractValidator<UpdateProductCommandRequest>
	{
        public UpdateProductCommandValidator()
        {
			RuleFor(x => x.ProductName).NotEmpty().WithMessage(ProductsMessages.ProductNameNotNull)
					.MaximumLength(128).WithMessage(ProductsMessages.ProductNameMaxLenght);

			RuleFor(x => x.Description).MaximumLength(255).WithMessage(ProductsMessages.DescriptionMaxLenght);
		}
    }
}
