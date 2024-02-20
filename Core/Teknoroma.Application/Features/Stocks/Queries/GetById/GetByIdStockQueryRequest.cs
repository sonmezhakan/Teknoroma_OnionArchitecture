using MediatR;

namespace Teknoroma.Application.Features.Stocks.Queries.GetById
{
    public class GetByIdStockQueryRequest : IRequest<GetByIdStockQueryResponse>
    {
        public Guid BranchID { get; set; }
        public Guid ProductID { get; set; }
    }
}
