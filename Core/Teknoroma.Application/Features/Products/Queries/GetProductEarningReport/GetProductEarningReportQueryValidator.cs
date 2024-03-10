using FluentValidation;
using Teknoroma.Application.Features.Products.Constants;

namespace Teknoroma.Application.Features.Products.Queries.GetProductEarningReport
{
    public class GetProductEarningReportQueryValidator:AbstractValidator<GetProductEarningReportQueryRequest>
    {
        public GetProductEarningReportQueryValidator()
        {
            RuleFor(x => x.StartDate).NotNull().WithMessage(ProductsMessages.StartDateTimeNotNull);
            RuleFor(x => x.EndDate).NotNull().WithMessage(ProductsMessages.EndDateTimeNotNull);
        }
    }
}
