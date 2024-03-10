using FluentValidation;
using Teknoroma.Application.Features.Categories.Constants;

namespace Teknoroma.Application.Features.Categories.Queries.GetCategorySellingReport
{
    public class GetCategorySellingReportQueryVallidator:AbstractValidator<GetCategorySellingReportQueryRequest>
    {
        public GetCategorySellingReportQueryVallidator()
        {
            RuleFor(x => x.StartDate).NotNull().WithMessage(CategoryMessages.StartDateTimeNotNull);
            RuleFor(x => x.EndDate).NotNull().WithMessage(CategoryMessages.EndDateTimeNotNull);
        }
    }
}
