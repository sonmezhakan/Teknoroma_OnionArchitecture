using FluentValidation;
using Teknoroma.Application.Features.Branches.Constants;

namespace Teknoroma.Application.Features.Branches.Queries.GetBranchSellingReport
{
    public class GetBranchSellingReportQueryValidator:AbstractValidator<GetBranchSellingReportQueryRequest>
    {
        public GetBranchSellingReportQueryValidator()
        {
            RuleFor(x => x.StartDate).NotEmpty().WithMessage(BranchesMessages.StartDateTimeNotNull);
            RuleFor(x => x.EndDate).NotEmpty().WithMessage(BranchesMessages.EndDateTimeNotNull);
        }
    }
}
