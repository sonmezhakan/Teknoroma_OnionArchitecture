using FluentValidation;
using Teknoroma.Application.Features.StockInputs.Contants;

namespace Teknoroma.Application.Features.StockInputs.Command.Create
{
    public class CreateStockInputCommandValidator:AbstractValidator<CreateStockInputCommandRequest>
    {
        public CreateStockInputCommandValidator()
        {
            RuleFor(x=>x.BranchID).NotEmpty().WithMessage(StockInputsMessages.BranchNotNull);

            RuleFor(x => x.ProductID).NotEmpty().WithMessage(StockInputsMessages.ProductNotNull);

            RuleFor(x => x.Description).MaximumLength(255).WithMessage(StockInputsMessages.DescriptionMaxLenght);

            RuleFor(x => x.InoviceNumber).MaximumLength(128).WithMessage(StockInputsMessages.InoviceMaxLenght);

            RuleFor(x => x.Quantity).NotEmpty().WithMessage(StockInputsMessages.QuantityNotNull);
        }
    }
}
