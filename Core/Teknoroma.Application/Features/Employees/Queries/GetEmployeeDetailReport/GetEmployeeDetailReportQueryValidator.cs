using FluentValidation;
using Teknoroma.Application.Features.Employees.Contants;

namespace Teknoroma.Application.Features.Employees.Queries.GetEmployeeDetailReport
{
    public class GetEmployeeDetailReportQueryValidator:AbstractValidator<GetEmployeeDetailReportQueryRequest>
    {
        public GetEmployeeDetailReportQueryValidator()
        {
            RuleFor(x => x.StartDate).NotNull().WithMessage(EmployeesMessages.StartDateTimeNotNull);
            RuleFor(x => x.EndDate).NotNull().WithMessage(EmployeesMessages.EndDateTimeNotNull);
        }
    }
}
