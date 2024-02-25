using FluentValidation;
using Teknoroma.Application.Features.Employees.Contants;

namespace Teknoroma.Application.Features.Employees.Command.Delete
{
	public class DeleteEmployeeCommandValidator:AbstractValidator<DeleteEmployeeCommandRequest>
	{
        public DeleteEmployeeCommandValidator()
        {
			RuleFor(x => x.ID).NotEmpty().WithMessage(EmployeesMessages.AppUserIDNotNull);
		}
    }
}
