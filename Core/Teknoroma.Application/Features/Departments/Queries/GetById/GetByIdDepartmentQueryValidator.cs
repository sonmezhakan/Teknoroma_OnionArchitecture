using FluentValidation;
using Teknoroma.Application.Features.Departments.Contants;

namespace Teknoroma.Application.Features.Departments.Queries.GetById
{
	public class GetByIdDepartmentQueryValidator:AbstractValidator<GetByIdDepartmentQueryRequest>
	{
        public GetByIdDepartmentQueryValidator()
        {
			RuleFor(x => x.ID).NotEmpty().WithMessage(DepartmentsMessages.IDNotNull);
		}
    }
}
