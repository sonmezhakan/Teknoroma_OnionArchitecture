using FluentValidation;
using Teknoroma.Application.Features.Products.Constants;

namespace Teknoroma.Application.Features.Products.Queries.GetProductSupplyReport
{
    public class GetProductSupplyReportQueryValidator:AbstractValidator<GetProductSupplyReportQueryRequest>
    {
        public GetProductSupplyReportQueryValidator()
        {
            RuleFor(x => x.StartDate).NotNull().WithMessage(ProductsMessages.StartDateTimeNotNull);
            RuleFor(x => x.EndDate).NotNull().WithMessage(ProductsMessages.EndDateTimeNotNull);
        }
    }
}
