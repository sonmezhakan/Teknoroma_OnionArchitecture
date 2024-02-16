using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.Categories.Commands.Create
{
    public class CreateCategoryCommandValidator:AbstractValidator<CreateCategoryCommandRequest>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(c => c.CategoryName).NotEmpty().MaximumLength(64);
            RuleFor(c => c.Description).MaximumLength(255);

        }
    }
}
