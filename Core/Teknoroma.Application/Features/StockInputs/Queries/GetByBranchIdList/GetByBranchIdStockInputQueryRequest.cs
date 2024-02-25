using MediatR;

namespace Teknoroma.Application.Features.StockInputs.Queries.GetByBranchIdList
{
    public class GetByBranchIdStockInputQueryRequest:IRequest<List<GetByBranchIdStockInputQueryResponse>>
    {
        public Guid BranchId { get; set; }
    }
}
