using FluentValidation;
using Teknoroma.Application.Features.Employees.Contants;

namespace Teknoroma.Application.Features.Employees.Command.Create
{
	public class CreateEmployeeCommandValidator:AbstractValidator<CreateEmployeeCommandRequest>
	{
        public CreateEmployeeCommandValidator()
        {
            RuleFor(x=>x.BranchID).NotEmpty().WithMessage(EmployeesMessages.BranchIDNotNull);

            RuleFor(x => x.DepartmentID).NotEmpty().WithMessage(EmployeesMessages.DepartmentIDNotNull);

            RuleFor(x => x.ID).NotEmpty().WithMessage(EmployeesMessages.AppUserIDNotNull);
        }
    }
}
