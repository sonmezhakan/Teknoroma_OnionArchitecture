using FluentValidation;
using Teknoroma.Application.Features.Suppliers.Contants;

namespace Teknoroma.Application.Features.Suppliers.Queries.GetSupplierSupplyDetailReport
{
    public class GetSupplierSuupplyDetailReportQueryValidator:AbstractValidator<GetSupplierSupplyDetailReportQueryRequest>
    {
        public GetSupplierSuupplyDetailReportQueryValidator()
        {
            RuleFor(x => x.StartDate).NotNull().WithMessage(SuppliersMessages.StartDateTimeNotNull);
            RuleFor(x => x.EndDate).NotNull().WithMessage(SuppliersMessages.EndDateTimeNotNull);

        }
    }
}
