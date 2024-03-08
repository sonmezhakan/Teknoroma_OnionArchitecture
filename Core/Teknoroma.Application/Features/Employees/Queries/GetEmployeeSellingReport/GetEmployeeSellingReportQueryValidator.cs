using FluentValidation;
using Teknoroma.Application.Features.Employees.Contants;

namespace Teknoroma.Application.Features.Employees.Queries.GetEmployeeSellingReport
{
    public class GetEmployeeSellingReportQueryValidator:AbstractValidator<GetEmployeeSellingReportQueryRequest>
    {
        public GetEmployeeSellingReportQueryValidator()
        {
            RuleFor(x => x.StartDate).NotEmpty().WithMessage(EmployeesMessages.StartDateTimeNotNull);
            RuleFor(x => x.EndDate).NotEmpty().WithMessage(EmployeesMessages.EndDateTimeNotNull);
        }
    }
}
