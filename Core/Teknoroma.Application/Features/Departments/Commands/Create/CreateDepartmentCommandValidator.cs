using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Features.Brands.Contants;
using Teknoroma.Application.Features.Departments.Contants;

namespace Teknoroma.Application.Features.Departments.Command.Create
{
	public class CreateDepartmentCommandValidator:AbstractValidator<CreateDepartmentCommandRequest>
	{
        public CreateDepartmentCommandValidator()
        {
            RuleFor(x => x.DepartmentName).NotEmpty().WithMessage(DepartmentsMessages.DepartmentNotNull)
                .MaximumLength(64).WithMessage(DepartmentsMessages.DepartmentNameMaxLenght);

			RuleFor(x => x.Description).MaximumLength(255).WithMessage(DepartmentsMessages.DescriptionMaxLenght);
		}
    }
}
