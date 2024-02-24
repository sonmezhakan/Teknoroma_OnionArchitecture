using FluentValidation;

namespace Teknoroma.Application.Features.Orders.Command.Update
{
	public class UpdateOrderCommandValidator:AbstractValidator<UpdateOrderCommandRequest>
	{
        public UpdateOrderCommandValidator()
        {
			RuleFor(x => x.ID).NotEmpty().WithMessage("");

			RuleFor(x => x.BranchID).NotEmpty().WithMessage("");

			RuleFor(x => x.EmployeeID).NotEmpty().WithMessage("");

			RuleFor(x => x.CustomerID).NotEmpty().WithMessage("");

			RuleFor(x => x.OrderDate).NotEmpty().WithMessage("");

			RuleFor(x => x.OrderStatu).NotEmpty().WithMessage("");
		}
    }
}
