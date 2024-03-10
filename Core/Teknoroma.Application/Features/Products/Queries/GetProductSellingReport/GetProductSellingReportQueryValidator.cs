using FluentValidation;
using Teknoroma.Application.Features.Products.Constants;

namespace Teknoroma.Application.Features.Products.Queries.GetProductSellingReport
{
    public class GetProductSellingReportQueryValidator:AbstractValidator<GetProductSellingReportQueryRequest>
    {
        public GetProductSellingReportQueryValidator()
        {
            RuleFor(x => x.StartDate).NotNull().WithMessage(ProductsMessages.StartDateTimeNotNull);
            RuleFor(x => x.EndDate).NotNull().WithMessage(ProductsMessages.EndDateTimeNotNull);
        }
    }
}
