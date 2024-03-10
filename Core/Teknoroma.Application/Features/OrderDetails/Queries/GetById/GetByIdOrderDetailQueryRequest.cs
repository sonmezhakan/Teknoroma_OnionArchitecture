using MediatR;

namespace Teknoroma.Application.Features.OrderDetails.Queries.GetById
{
	public class GetByIdOrderDetailQueryRequest:IRequest<GetByIdOrderDetailQueryResponse>
	{
        public Guid ID { get; set; }
    }
}
