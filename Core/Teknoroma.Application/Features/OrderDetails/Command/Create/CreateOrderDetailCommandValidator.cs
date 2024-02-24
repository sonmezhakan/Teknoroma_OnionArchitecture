using FluentValidation;

namespace Teknoroma.Application.Features.OrderDetails.Command.Create
{
	public class CreateOrderDetailCommandValidator:AbstractValidator<CreateOrderDetailCommandRequest>
	{
        public CreateOrderDetailCommandValidator()
        {
            RuleFor(x=>x.ID).NotEmpty().WithMessage("");

            RuleFor(x => x.CartItems).NotEmpty().WithMessage("");
        }
    }
}
