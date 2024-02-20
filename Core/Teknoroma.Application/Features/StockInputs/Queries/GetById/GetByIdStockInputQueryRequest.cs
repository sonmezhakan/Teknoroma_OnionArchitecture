using MediatR;

namespace Teknoroma.Application.Features.StockInputs.Queries.GetById
{
    public class GetByIdStockInputQueryRequest:IRequest<GetByIdStockInputQueryResponse>
    {
        public Guid ID { get; set; }
    }
}
