using FluentValidation;
using Teknoroma.Application.Features.Stocks.Contants;

namespace Teknoroma.Application.Features.Stocks.Queries.GetByBranchId
{
    public class GetByBranchIdStockQueryValidator:AbstractValidator<GetByBranchIdStockQueryRequest>
    {
        public GetByBranchIdStockQueryValidator()
        {
            RuleFor(x => x.BranchID).NotEmpty().WithMessage(StockMessages.BranchIdNotNull);
        }
    }
}
