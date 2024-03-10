using FluentValidation;
using Teknoroma.Application.Features.Products.Constants;

namespace Teknoroma.Application.Features.Products.Queries.GetProductSalesDetailReport
{
    public class GetProductSalesDetailReportQueryValidator:AbstractValidator<GetProductSalesDetailReportQueryRequest>
    {
        public GetProductSalesDetailReportQueryValidator()
        {
            RuleFor(x => x.StartDate).NotNull().WithMessage(ProductsMessages.StartDateTimeNotNull);
            RuleFor(x => x.EndDate).NotNull().WithMessage(ProductsMessages.EndDateTimeNotNull);
        }
    }
}
