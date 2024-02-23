using MediatR;

namespace Teknoroma.Application.Features.Orders.Queries.GetList
{
	public class GetAllOrderQueryRequest:IRequest<List<GetAllOrderQueryResponse>>
	{
	}
}
