using FluentValidation;
using Teknoroma.Application.Features.Suppliers.Contants;

namespace Teknoroma.Application.Features.Suppliers.Queries.GetSupplyReport
{
    public class GetSupplierSupplyReportQueryValidator:AbstractValidator<GetSupplierSupplyReportQueryRequest>
    {
        public GetSupplierSupplyReportQueryValidator()
        {
            RuleFor(x => x.StartDate).NotEmpty().WithMessage(SuppliersMessages.StartDateTimeNotNull);
            RuleFor(x => x.EndDate).NotEmpty().WithMessage(SuppliersMessages.EndDateTimeNotNull);
        }
    }
}
