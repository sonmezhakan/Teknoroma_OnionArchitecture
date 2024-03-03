using FluentValidation;
using Teknoroma.Application.Features.Products.Constants;

namespace Teknoroma.Application.Features.Products.Queries.GetByBarcodeCode
{
	public class GetByBarcodeCodeQueryValidator:AbstractValidator<GetByBarcodeCodeQueryRequest>
	{
        public GetByBarcodeCodeQueryValidator()
        {
            RuleFor(x => x.BarcodeCode).NotEmpty().WithMessage(ProductsMessages.BarcodeCodeNotNull)
                .MaximumLength(32).WithMessage(ProductsMessages.BarcodeCodeMaxLenght);
        }
    }
}
