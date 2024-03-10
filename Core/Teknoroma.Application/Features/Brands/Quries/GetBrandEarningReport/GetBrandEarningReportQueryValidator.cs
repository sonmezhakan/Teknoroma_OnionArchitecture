using FluentValidation;
using Teknoroma.Application.Features.Brands.Contants;

namespace Teknoroma.Application.Features.Brands.Quries.GetBrandEarningReport
{
    public class GetBrandEarningReportQueryValidator:AbstractValidator<GetBrandEarningReportQueryRequest>
    {
        public GetBrandEarningReportQueryValidator()
        {
            RuleFor(x => x.StartDate).NotNull().WithMessage(BrandsMessages.StartDateTimeNotNull);
            RuleFor(x => x.EndDate).NotNull().WithMessage(BrandsMessages.EndDateTimeNotNull);
        }
    }
}
