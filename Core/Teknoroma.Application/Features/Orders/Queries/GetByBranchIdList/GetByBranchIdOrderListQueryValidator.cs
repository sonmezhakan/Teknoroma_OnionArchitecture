using FluentValidation;
using Teknoroma.Application.Features.Orders.Contants;

namespace Teknoroma.Application.Features.Orders.Queries.GetByBranchIdList
{
	public class GetByBranchIdOrderListQueryValidator:AbstractValidator<GetByBranchIdOrderListQueryRequest>
    {
        public GetByBranchIdOrderListQueryValidator()
        {
			RuleFor(x => x.BranchId).NotEmpty().WithMessage(OrdersMessages.BranchIDNotNull);
		}
    }
}
