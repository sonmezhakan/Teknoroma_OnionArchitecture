using FluentValidation;
using Teknoroma.Application.Features.Expenses.Contants;

namespace Teknoroma.Application.Features.Expenses.Queries.GetById
{
	public class GetByIdExpenseQueryValidator:AbstractValidator<GetByIdExpenseQueryRequest>
	{
		public GetByIdExpenseQueryValidator()
		{
			RuleFor(x=>x.ID).NotEmpty().WithMessage(ExpenseMessages.IDNotNull);
		}
	}
}
