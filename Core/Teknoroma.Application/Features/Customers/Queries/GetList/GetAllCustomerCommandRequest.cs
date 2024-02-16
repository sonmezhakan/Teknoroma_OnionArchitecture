using MediatR;


namespace Teknoroma.Application.Features.Customers.Queries.GetList
{
	public class GetAllCustomerCommandRequest:IRequest<List<GetAllCustomerCommandResponse>>
	{
	}
}
