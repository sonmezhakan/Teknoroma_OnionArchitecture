using FluentValidation;
using Teknoroma.Application.Features.Products.Constants;

namespace Teknoroma.Application.Features.Products.Queries.GetProductSupplyDetailReport
{
    public class GetProductSupplyDetailReportQueryValidator:AbstractValidator<GetProductSupplyDetailReportQueryRequest>
    {
        public GetProductSupplyDetailReportQueryValidator()
        {
            RuleFor(x => x.StartDate).NotNull().WithMessage(ProductsMessages.StartDateTimeNotNull);
            RuleFor(x => x.EndDate).NotNull().WithMessage(ProductsMessages.EndDateTimeNotNull);
        }
    }
}
