using FluentValidation;
using Teknoroma.Application.Features.Expenses.Contants;

namespace Teknoroma.Application.Features.Expenses.Commands.Delete
{
	public class DeleteExpenseCommandValidator:AbstractValidator<DeleteExpenseCommandRequest>
	{
        public DeleteExpenseCommandValidator()
        {
			RuleFor(x => x.ID).NotEmpty().WithMessage(ExpenseMessages.IDNotNull);
		}
    }
}
