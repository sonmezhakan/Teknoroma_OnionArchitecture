using FluentValidation;
using Teknoroma.Application.Features.Stocks.Contants;

namespace Teknoroma.Application.Features.Stocks.Command.Update
{
    public class UpdateStockCommandValidator:AbstractValidator<UpdateStockCommandRequest>
    {
        public UpdateStockCommandValidator()
        {
            RuleFor(x => x.BranchId).NotEmpty().WithMessage(StockMessages.BranchIdNotNull);
            RuleFor(x => x.ProductId).NotEmpty().WithMessage(StockMessages.ProductIdNotNull);
            RuleFor(x => x.UnitsInStock).NotEmpty().WithMessage(StockMessages.UnitsInStockNotNull);
        }
    }
}
