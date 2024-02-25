using FluentValidation;
using Teknoroma.Application.Features.Orders.Contants;

namespace Teknoroma.Application.Features.Orders.Command.Delete
{
	public class DeleteOrderCommandValidator:AbstractValidator<DeleteOrderCommandRequest>
	{
        public DeleteOrderCommandValidator()
        {
			RuleFor(x => x.ID).NotEmpty().WithMessage(OrdersMessages.IDNotNull);
		}
    }
}
