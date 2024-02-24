using FluentValidation;
using Teknoroma.Application.Features.Orders.Contants;

namespace Teknoroma.Application.Features.Orders.Command.Create
{
	abstract class CreateOrderCommandValidator:AbstractValidator<CreateOrderCommandRequest>
	{
        public CreateOrderCommandValidator()
        {
            RuleFor(x=>x.BranchId).NotEmpty().WithMessage(OrdersMessages.BranchIDNotNull);

            RuleFor(x => x.EmployeeId).NotEmpty().WithMessage(OrdersMessages.EmployeeIDNotNull);

            RuleFor(x => x.CustomerId).NotEmpty().WithMessage(OrdersMessages.CustomerIDNotnull);

            RuleFor(x => x.CartItems).NotEmpty().WithMessage(OrdersMessages.CartItemsNotNull);
        }
    }
}
