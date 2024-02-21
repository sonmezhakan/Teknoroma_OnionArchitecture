using MediatR;

namespace Teknoroma.Application.Features.Employees.Queries.GetList
{
	public class GetAllEmployeeQueryRequest:IRequest<List<GetAllEmployeeQueryResponse>>
	{
	}
}
