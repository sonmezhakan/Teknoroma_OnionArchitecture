using FluentValidation;
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
