using FluentValidation;
using Teknoroma.Application.Features.Departments.Contants;

namespace Teknoroma.Application.Features.Departments.Command.Delete
{
	public class DeleteDepartmentCommandValidator:AbstractValidator<DeleteDepartmentCommandRequest>
	{
        public DeleteDepartmentCommandValidator()
        {
            RuleFor(x=>x.ID).NotEmpty().WithMessage(DepartmentsMessages.IDNotNull);
        }
    }
}
