using FluentValidation;

namespace Teknoroma.Application.Features.OrderDetails.Command.Update
{
	public class UpdateOrderDetailCommandValidator:AbstractValidator<UpdateOrderDetailCommandRequest>
	{
        public UpdateOrderDetailCommandValidator()
        {
			RuleFor(x => x.OrderId).NotEmpty().WithMessage("");

			RuleFor(x => x.BranchId).NotEmpty().WithMessage("");

			RuleFor(x => x.ProductId).NotEmpty().WithMessage("");

			RuleFor(x => x.Quantity).NotEmpty().WithMessage("");

			RuleFor(x => x.UnitPrice).NotEmpty().WithMessage("");
		}
    }
}
