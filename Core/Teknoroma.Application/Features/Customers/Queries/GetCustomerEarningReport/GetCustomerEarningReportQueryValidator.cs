using FluentValidation;
using Teknoroma.Application.Features.Customers.Contants;

namespace Teknoroma.Application.Features.Customers.Queries.GetCustomerEarningReport
{
    public class GetCustomerEarningReportQueryValidator:AbstractValidator<GetCustomerEarningReportQueryRequest>
    {
        public GetCustomerEarningReportQueryValidator()
        {
            RuleFor(x => x.StartDate).NotEmpty().WithMessage(CustomersMessages.StartDateTimeNotNull);
            RuleFor(x => x.EndDate).NotEmpty().WithMessage(CustomersMessages.EndDateTimeNotNull);
        }
    }
}
