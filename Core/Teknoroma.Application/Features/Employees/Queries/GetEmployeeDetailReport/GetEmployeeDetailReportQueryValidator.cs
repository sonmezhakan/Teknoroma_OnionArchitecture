using FluentValidation;
using Teknoroma.Application.Features.Employees.Contants;

namespace Teknoroma.Application.Features.Employees.Queries.GetEmployeeDetailReport
{
    public class GetEmployeeDetailReportQueryValidator:AbstractValidator<GetEmployeeDetailReportQueryRequest>
    {
        public GetEmployeeDetailReportQueryValidator()
        {
            RuleFor(x => x.StartDate).NotEmpty().WithMessage(EmployeesMessages.StartDateTimeNotNull);
            RuleFor(x => x.EndDate).NotEmpty().WithMessage(EmployeesMessages.EndDateTimeNotNull);
        }
    }
}
