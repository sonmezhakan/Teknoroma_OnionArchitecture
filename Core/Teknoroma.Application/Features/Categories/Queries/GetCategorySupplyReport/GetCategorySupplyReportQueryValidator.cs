using FluentValidation;
using Teknoroma.Application.Features.Categories.Constants;

namespace Teknoroma.Application.Features.Categories.Queries.GetCategorySupplyReport
{
    public class GetCategorySupplyReportQueryValidator:AbstractValidator<GetCategorySupplyReportQueryRequest>
    {
        public GetCategorySupplyReportQueryValidator()
        {
            RuleFor(x => x.StartDate).NotEmpty().WithMessage(CategoryMessages.StartDateTimeNotNull);
            RuleFor(x => x.EndDate).NotEmpty().WithMessage(CategoryMessages.EndDateTimeNotNull);
        }
    }
}
