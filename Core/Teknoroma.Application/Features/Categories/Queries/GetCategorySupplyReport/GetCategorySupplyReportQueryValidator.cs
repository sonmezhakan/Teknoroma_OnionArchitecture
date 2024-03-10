using FluentValidation;
using Teknoroma.Application.Features.Categories.Constants;

namespace Teknoroma.Application.Features.Categories.Queries.GetCategorySupplyReport
{
    public class GetCategorySupplyReportQueryValidator:AbstractValidator<GetCategorySupplyReportQueryRequest>
    {
        public GetCategorySupplyReportQueryValidator()
        {
            RuleFor(x => x.StartDate).NotNull().WithMessage(CategoryMessages.StartDateTimeNotNull);
            RuleFor(x => x.EndDate).NotNull().WithMessage(CategoryMessages.EndDateTimeNotNull);
        }
    }
}
