using FluentValidation;
using Teknoroma.Application.Features.Customers.Contants;

namespace Teknoroma.Application.Features.Customers.Queries.GetCustomerSellingReport
{
    public class GetCustomerSellingReportQueryValidator:AbstractValidator<GetCustomerSellingReportQueryRequest>
    {
        public GetCustomerSellingReportQueryValidator()
        {
            RuleFor(x => x.StartDate).NotNull().WithMessage(CustomersMessages.StartDateTimeNotNull);
            RuleFor(x => x.EndDate).NotNull().WithMessage(CustomersMessages.EndDateTimeNotNull);
        }
    }
}
