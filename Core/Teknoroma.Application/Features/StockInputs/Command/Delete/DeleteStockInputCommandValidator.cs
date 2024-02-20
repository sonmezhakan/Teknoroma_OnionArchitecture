using FluentValidation;
using Teknoroma.Application.Features.StockInputs.Contants;

namespace Teknoroma.Application.Features.StockInputs.Command.Delete
{
    public class DeleteStockInputCommandValidator:AbstractValidator<DeleteStockInputCommandRequest>
    {
        public DeleteStockInputCommandValidator()
        {
            RuleFor(x => x.ID).NotEmpty().WithMessage(StockInputsMessages.IDNotNull);
        }
    }
}
