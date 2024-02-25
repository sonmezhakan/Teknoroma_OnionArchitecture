using FluentValidation;
using Teknoroma.Application.Features.OrderDetails.Contants;

namespace Teknoroma.Application.Features.OrderDetails.Command.Delete
{
	public class DeleteOrderDetailCommandValidator:AbstractValidator<DeleteOrderDetailCommandRequest>
	{
        public DeleteOrderDetailCommandValidator()
        {
            RuleFor(x=>x.OrderId).NotEmpty().WithMessage(OrderDetailsMessages.IDNotNull);

            RuleFor(x => x.BranchId).NotEmpty().WithMessage(OrderDetailsMessages.BranchIDNotNull);

            RuleFor(x => x.ProductId).NotEmpty().WithMessage(OrderDetailsMessages.ProductIDNotNull);
        }
    }
}
