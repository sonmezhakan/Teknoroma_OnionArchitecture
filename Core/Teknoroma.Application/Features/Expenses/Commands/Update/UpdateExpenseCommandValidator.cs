using FluentValidation;
using Teknoroma.Application.Features.Expenses.Contants;

namespace Teknoroma.Application.Features.Expenses.Commands.Update
{
	public class UpdateExpenseCommandValidator:AbstractValidator<UpdateExpenseCommandRequest>
	{
        public UpdateExpenseCommandValidator()
        {
			RuleFor(x => x.ID).NotEmpty().WithMessage(ExpenseMessages.IDNotNull);

			RuleFor(x => x.Title).NotEmpty().WithMessage(ExpenseMessages.TitleNotNull)
				.MaximumLength(128).WithMessage(ExpenseMessages.TitleMaxLenght);

			RuleFor(x => x.Price).NotNull().WithMessage(ExpenseMessages.PriceNotNull)
				.NotEmpty().WithMessage(ExpenseMessages.PriceNotNull);

			RuleFor(x => x.Description).MaximumLength(500).WithMessage(ExpenseMessages.DescriptionMaxLenght);
		}
    }
}
