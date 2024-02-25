using FluentValidation;
using Teknoroma.Application.Features.Orders.Contants;

namespace Teknoroma.Application.Features.Orders.Command.Update
{
	public class UpdateOrderCommandValidator:AbstractValidator<UpdateOrderCommandRequest>
	{
        public UpdateOrderCommandValidator()
        {
			RuleFor(x => x.ID).NotEmpty().WithMessage(OrdersMessages.IDNotNull);

			RuleFor(x => x.BranchID).NotEmpty().WithMessage(OrdersMessages.BranchIDNotNull);

			RuleFor(x => x.EmployeeID).NotEmpty().WithMessage(OrdersMessages.EmployeeIDNotNull);

			RuleFor(x => x.CustomerID).NotEmpty().WithMessage(OrdersMessages.CustomerIDNotnull);
		}
    }
}
