using FluentValidation;
using Teknoroma.Application.Features.Employees.Contants;

namespace Teknoroma.Application.Features.Employees.Queries.GetById
{
    public class GetByIdEmployeeQueryValidator : AbstractValidator<GetByIdEmployeeQueryRequest>
    {
        public GetByIdEmployeeQueryValidator()
        {
            RuleFor(x => x.ID).NotEmpty().WithMessage(EmployeesMessages.AppUserIDNotNull);
        }
    }
}
