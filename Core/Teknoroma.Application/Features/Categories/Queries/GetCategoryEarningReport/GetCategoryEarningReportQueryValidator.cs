using FluentValidation;
using Teknoroma.Application.Features.Categories.Constants;

namespace Teknoroma.Application.Features.Categories.Queries.GetCategoryEarningReport
{
    public class GetCategoryEarningReportQueryValidator:AbstractValidator<GetCategoryEarningReportQueryRequest>
    {
        public GetCategoryEarningReportQueryValidator()
        {
            RuleFor(x => x.StartDate).NotEmpty().WithMessage(CategoryMessages.StartDateTimeNotNull);
            RuleFor(x => x.EndDate).NotEmpty().WithMessage(CategoryMessages.EndDateTimeNotNull);
        }
    }
}
