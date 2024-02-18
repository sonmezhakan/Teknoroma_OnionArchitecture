using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Features.Categories.Constants;

namespace Teknoroma.Application.Features.Categories.Commands.Update
{
    public class UpdateCategoryCommandValidator:AbstractValidator<UpdateCategoryCommandRequest>
    {
        public UpdateCategoryCommandValidator()
        {
			RuleFor(x => x.CategoryName).NotEmpty().WithMessage(CategoryMessages.CategoryNameNotNull)
					.MaximumLength(128).WithMessage(CategoryMessages.CategoryNameMaxLenght);

			RuleFor(x => x.Description).MaximumLength(255).WithMessage(CategoryMessages.DescriptionMaxLenght);
		}
    }
}
