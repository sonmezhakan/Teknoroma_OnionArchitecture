using FluentValidation;
using Teknoroma.Application.Features.OrderDetails.Contants;

namespace Teknoroma.Application.Features.OrderDetails.Command.Update
{
	public class UpdateOrderDetailCommandValidator:AbstractValidator<UpdateOrderDetailCommandRequest>
	{
        public UpdateOrderDetailCommandValidator()
        {
			RuleFor(x => x.OrderId).NotEmpty().WithMessage(OrderDetailsMessages.IDNotNull);

			RuleFor(x => x.BranchId).NotEmpty().WithMessage(OrderDetailsMessages.BranchIDNotNull);

			RuleFor(x => x.ProductId).NotEmpty().WithMessage(OrderDetailsMessages.ProductIDNotNull);

			RuleFor(x => x.Quantity).NotEmpty().WithMessage(OrderDetailsMessages.IDNotNull);

		}
    }
}
