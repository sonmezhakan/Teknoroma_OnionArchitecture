using FluentValidation;
using Teknoroma.Application.Features.Categories.Constants;

namespace Teknoroma.Application.Features.Categories.Commands.Create
{
    public class CreateCategoryCommandValidator:AbstractValidator<CreateCategoryCommandRequest>
    {
        public CreateCategoryCommandValidator()
        {
			RuleFor(x => x.CategoryName).NotEmpty().WithMessage(CategoryMessages.CategoryNameNotNull)
					.MaximumLength(128).WithMessage(CategoryMessages.CategoryNameMaxLenght);

			RuleFor(x => x.Description).MaximumLength(255).WithMessage(CategoryMessages.DescriptionMaxLenght);
		}
    }
}
