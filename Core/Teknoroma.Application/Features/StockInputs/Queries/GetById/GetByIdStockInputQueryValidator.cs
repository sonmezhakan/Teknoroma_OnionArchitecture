using FluentValidation;
using Teknoroma.Application.Features.StockInputs.Contants;

namespace Teknoroma.Application.Features.StockInputs.Queries.GetById
{
    public class GetByIdStockInputQueryValidator:AbstractValidator<GetByIdStockInputQueryRequest>
    {
        public GetByIdStockInputQueryValidator()
        {
            RuleFor(x => x.ID).NotEmpty().WithMessage(StockInputsMessages.IDNotNull);
        }
    }
}
