using FluentValidation;

namespace Teknoroma.Application.Features.StockInputs.Queries.GetByBranchIdList
{
    public class GetByBranchIdStockInputQueryValidator:AbstractValidator<GetByBranchIdStockInputQueryRequest>
    {
        public GetByBranchIdStockInputQueryValidator()
        {
            RuleFor(x => x.BranchId).NotEmpty();
        }
    }
}
