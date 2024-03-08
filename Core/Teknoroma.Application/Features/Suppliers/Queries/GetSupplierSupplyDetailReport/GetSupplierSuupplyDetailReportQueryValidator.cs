using FluentValidation;
using Teknoroma.Application.Features.Suppliers.Contants;

namespace Teknoroma.Application.Features.Suppliers.Queries.GetSupplierSupplyDetailReport
{
    public class GetSupplierSuupplyDetailReportQueryValidator:AbstractValidator<GetSupplierSupplyDetailReportQueryRequest>
    {
        public GetSupplierSuupplyDetailReportQueryValidator()
        {
            RuleFor(x => x.StartDate).NotEmpty().WithMessage(SuppliersMessages.StartDateTimeNotNull);
            RuleFor(x => x.EndDate).NotEmpty().WithMessage(SuppliersMessages.EndDateTimeNotNull);

        }
    }
}
