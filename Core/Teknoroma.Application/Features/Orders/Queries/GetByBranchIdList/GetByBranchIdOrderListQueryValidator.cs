using FluentValidation;

namespace Teknoroma.Application.Features.Orders.Queries.GetByBranchIdList
{
	public class GetByBranchIdOrderListQueryValidator:AbstractValidator<GetByBranchIdOrderListQueryRequest>
    {
        public GetByBranchIdOrderListQueryValidator()
        {
			RuleFor(x => x.BranchId).NotEmpty().WithMessage("");
		}
    }
}
