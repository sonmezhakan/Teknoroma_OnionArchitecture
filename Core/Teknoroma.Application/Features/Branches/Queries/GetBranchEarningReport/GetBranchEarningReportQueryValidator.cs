using FluentValidation;
using Teknoroma.Application.Features.Branches.Constants;

namespace Teknoroma.Application.Features.Branches.Queries.GetBranchEarningReport
{
    public class GetBranchEarningReportQueryValidator:AbstractValidator<GetBranchEarningReportQueryRequest>
    {
        public GetBranchEarningReportQueryValidator()
        {
            RuleFor(x => x.StartDate).NotEmpty().WithMessage(BranchesMessages.StartDateTimeNotNull);
            RuleFor(x => x.EndDate).NotEmpty().WithMessage(BranchesMessages.EndDateTimeNotNull);
        }
    }
}
