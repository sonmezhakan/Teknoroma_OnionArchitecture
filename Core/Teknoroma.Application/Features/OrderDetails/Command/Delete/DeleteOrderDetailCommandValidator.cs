using FluentValidation;

namespace Teknoroma.Application.Features.OrderDetails.Command.Delete
{
	public class DeleteOrderDetailCommandValidator:AbstractValidator<DeleteOrderDetailCommandRequest>
	{
        public DeleteOrderDetailCommandValidator()
        {
            RuleFor(x=>x.OrderId).NotEmpty().WithMessage("");

            RuleFor(x => x.BranchId).NotEmpty().WithMessage("");

            RuleFor(x => x.ProductId).NotEmpty().WithMessage("");
        }
    }
}
