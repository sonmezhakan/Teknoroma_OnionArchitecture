using FluentValidation;
using Teknoroma.Application.Features.OrderDetails.Contants;

namespace Teknoroma.Application.Features.OrderDetails.Command.Create
{
	public class CreateOrderDetailCommandValidator:AbstractValidator<CreateOrderDetailCommandRequest>
	{
        public CreateOrderDetailCommandValidator()
        {
            RuleFor(x=>x.ID).NotEmpty().WithMessage(OrderDetailsMessages.IDNotNull);

            RuleFor(x => x.CartItems).NotEmpty().WithMessage(OrderDetailsMessages.CartItemsNotNull);
        }
    }
}
