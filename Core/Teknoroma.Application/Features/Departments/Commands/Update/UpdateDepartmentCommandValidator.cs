using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Features.Departments.Contants;

namespace Teknoroma.Application.Features.Departments.Command.Update
{
	public class UpdateDepartmentCommandValidator:AbstractValidator<UpdateDepartmentCommandRequest>
	{
        public UpdateDepartmentCommandValidator()
        {
			RuleFor(x => x.ID).NotEmpty().WithMessage(DepartmentsMessages.IDNotNull);

			RuleFor(x => x.DepartmentName).NotEmpty().WithMessage(DepartmentsMessages.DepartmentNotNull)
				.MaximumLength(64).WithMessage(DepartmentsMessages.DepartmentNameMaxLenght);

			RuleFor(x => x.Description).MaximumLength(255).WithMessage(DepartmentsMessages.DescriptionMaxLenght);
		}
    }
}
