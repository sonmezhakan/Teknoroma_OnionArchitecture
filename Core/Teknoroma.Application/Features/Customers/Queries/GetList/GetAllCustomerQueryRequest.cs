using MediatR;


namespace Teknoroma.Application.Features.Customers.Queries.GetList
{
	public class GetAllCustomerQueryRequest:IRequest<List<GetAllCustomerQueryResponse>>
	{
	}
}
