using MediatR;

namespace Teknoroma.Application.Features.Stocks.Queries.GetByBranchId
{
    public class GetByBranchIdStockQueryRequest : IRequest<GetByBranchIdStockQueryResponse>
    {
        public Guid BranchID { get; set; }
    }
}
