using MediatR;

namespace Teknoroma.Application.Features.OrderDetails.Queries.GetByOrderAndProductId
{
	public class GetByOrderAndProductIdOrderDetailQueryRequest:IRequest<GetByOrderAndProductIdOrderDetailQueryResponse>
	{
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
    }
}
