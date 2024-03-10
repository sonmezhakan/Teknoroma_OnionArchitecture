using FluentValidation;
using Teknoroma.Application.Features.Customers.Contants;

namespace Teknoroma.Application.Features.Customers.Queries.GetCustomerEarningReport
{
    public class GetCustomerEarningReportQueryValidator:AbstractValidator<GetCustomerEarningReportQueryRequest>
    {
        public GetCustomerEarningReportQueryValidator()
        {
            RuleFor(x => x.StartDate).NotNull().WithMessage(CustomersMessages.StartDateTimeNotNull);
            RuleFor(x => x.EndDate).NotNull().WithMessage(CustomersMessages.EndDateTimeNotNull);
        }
    }
}
