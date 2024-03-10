using MediatR;

namespace Teknoroma.Application.Features.OrderDetails.Queries.GetList
{
	public class GetAllOrderDetailQueryRequest:IRequest<List<GetAllOrderDetailQueryResponse>>
	{
	}
}
