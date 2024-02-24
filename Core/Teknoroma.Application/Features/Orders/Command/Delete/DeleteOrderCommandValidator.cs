using FluentValidation;

namespace Teknoroma.Application.Features.Orders.Command.Delete
{
	public class DeleteOrderCommandValidator:AbstractValidator<DeleteOrderCommandRequest>
	{
        public DeleteOrderCommandValidator()
        {
			RuleFor(x => x.ID).NotEmpty().WithMessage("");
		}
    }
}
