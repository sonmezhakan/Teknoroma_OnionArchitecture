using FluentValidation;
using Teknoroma.Application.Features.Products.Constants;

namespace Teknoroma.Application.Features.Products.Queries.GetProductSellingReport
{
    public class GetProductSellingReportQueryValidator:AbstractValidator<GetProductSellingReportQueryRequest>
    {
        public GetProductSellingReportQueryValidator()
        {
            RuleFor(x => x.StartDate).NotEmpty().WithMessage(ProductsMessages.StartDateTimeNotNull);
            RuleFor(x => x.EndDate).NotEmpty().WithMessage(ProductsMessages.EndDateTimeNotNull);
        }
    }
}
