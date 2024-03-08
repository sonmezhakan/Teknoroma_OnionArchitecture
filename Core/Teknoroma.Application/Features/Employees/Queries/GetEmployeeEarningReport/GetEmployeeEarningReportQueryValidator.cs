using FluentValidation;
using Teknoroma.Application.Features.Employees.Contants;

namespace Teknoroma.Application.Features.Employees.Queries.GetEmployeeEarningReport
{
    public class GetEmployeeEarningReportQueryValidator:AbstractValidator<GetEmployeeEarningReportQueryRequest>
    {
        public GetEmployeeEarningReportQueryValidator()
        {
            RuleFor(x => x.StartDate).NotEmpty().WithMessage(EmployeesMessages.StartDateTimeNotNull);
            RuleFor(x => x.EndDate).NotEmpty().WithMessage(EmployeesMessages.EndDateTimeNotNull);
        }
    }
}
