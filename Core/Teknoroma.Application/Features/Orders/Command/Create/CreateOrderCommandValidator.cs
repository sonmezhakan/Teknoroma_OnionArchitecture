using FluentValidation;

namespace Teknoroma.Application.Features.Orders.Command.Create
{
	abstract class CreateOrderCommandValidator:AbstractValidator<CreateOrderCommandRequest>
	{
        public CreateOrderCommandValidator()
        {
            RuleFor(x=>x.BranchId).NotEmpty().WithMessage("");

            RuleFor(x => x.EmployeeId).NotEmpty().WithMessage("");

            RuleFor(x => x.CustomerId).NotEmpty().WithMessage("");

            RuleFor(x => x.OrderDate).NotEmpty().WithMessage("");

            RuleFor(x => x.OrderStatu).NotEmpty().WithMessage("");

            RuleFor(x => x.CartItems).NotEmpty().WithMessage("");
        }
    }
}
