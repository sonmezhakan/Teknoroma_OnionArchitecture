using MediatR;

namespace Teknoroma.Application.Features.OrderDetails.Queries.GetByProductId
{
	public class GetByProductIdOrderDetailQueryRequest:IRequest<List<GetByProductIdOrderDetailQueryResponse>>
	{
        public Guid ProductId { get; set; }
    }
}
