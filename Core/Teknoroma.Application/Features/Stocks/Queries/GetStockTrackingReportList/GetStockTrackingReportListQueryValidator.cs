using FluentValidation;
using Teknoroma.Application.Features.Stocks.Contants;

namespace Teknoroma.Application.Features.Stocks.Queries.GetStockTrackingReportList
{
	public class GetStockTrackingReportListQueryValidator:AbstractValidator<GetStockTrackingReportListQueryRequest>
	{
        public GetStockTrackingReportListQueryValidator()
        {
            RuleFor(x => x.BranchId).NotEmpty().WithMessage(StockMessages.BranchIdNotNull);
        }
    }
}
