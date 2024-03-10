using FluentValidation;
using Teknoroma.Application.Features.Branches.Constants;

namespace Teknoroma.Application.Features.Branches.Queries.GetBranchEarningReport
{
    public class GetBranchEarningReportQueryValidator:AbstractValidator<GetBranchEarningReportQueryRequest>
    {
        public GetBranchEarningReportQueryValidator()
        {
            RuleFor(x => x.StartDate).NotNull().WithMessage(BranchesMessages.StartDateTimeNotNull);
            RuleFor(x => x.EndDate).NotNull().WithMessage(BranchesMessages.EndDateTimeNotNull);
        }
    }
}
