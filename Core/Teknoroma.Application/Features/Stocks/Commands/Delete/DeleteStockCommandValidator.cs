using FluentValidation;

namespace Teknoroma.Application.Features.Stocks.Command.Delete
{
	public class DeleteStockCommandValidator:AbstractValidator<DeleteStockCommandRequest>
    {
        public DeleteStockCommandValidator()
        {
            RuleFor(x => x.BranchId).NotEmpty();
            RuleFor(x=>x.ProductId).NotEmpty();
        }
    }
}
