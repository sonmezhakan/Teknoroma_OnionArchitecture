using MediatR;

namespace Teknoroma.Application.Features.Orders.Queries.GetById
{
	public class GetByIdOrderQueryRequest:IRequest<GetByIdOrderQueryResponse>
	{
        public Guid ID { get; set; }
    }
}
