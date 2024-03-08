using FluentValidation;
using Teknoroma.Application.Features.Brands.Contants;

namespace Teknoroma.Application.Features.Brands.Quries.GetBrandSellingReport
{
    public class GetBrandSellingReportQueryValidator:AbstractValidator<GetBrandSellingReportQueryRequest>
    {
        public GetBrandSellingReportQueryValidator()
        {
            RuleFor(x => x.StartDate).NotEmpty().WithMessage(BrandsMessages.StartDateTimeNotNull);
            RuleFor(x => x.EndDate).NotEmpty().WithMessage(BrandsMessages.EndDateTimeNotNull);
        }
    }
}
