using FluentValidation;
using Teknoroma.Application.Features.Employees.Contants;

namespace Teknoroma.Application.Features.Employees.Queries.GetEmployeeEarningReport
{
    public class GetEmployeeEarningReportQueryValidator:AbstractValidator<GetEmployeeEarningReportQueryRequest>
    {
        public GetEmployeeEarningReportQueryValidator()
        {
            RuleFor(x => x.StartDate).NotNull().WithMessage(EmployeesMessages.StartDateTimeNotNull);
            RuleFor(x => x.EndDate).NotNull().WithMessage(EmployeesMessages.EndDateTimeNotNull);
        }
    }
}
