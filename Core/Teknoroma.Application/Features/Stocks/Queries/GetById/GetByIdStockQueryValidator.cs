using FluentValidation;
using Teknoroma.Application.Features.Stocks.Contants;

namespace Teknoroma.Application.Features.Stocks.Queries.GetById
{
    public class GetByIdStockQueryValidator:AbstractValidator<GetByIdStockQueryRequest>
    {
        public GetByIdStockQueryValidator()
        {
            RuleFor(x => x.BranchID).NotEmpty().WithMessage(StockMessages.BranchIdNotNull);
            RuleFor(x => x.ProductID).NotEmpty().WithMessage(StockMessages.ProductIdNotNull);
        }
    }
}
