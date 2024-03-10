using MediatR;

namespace Teknoroma.Application.Features.Employees.Queries.GetFullList
{
	public class GetFullListEmployeeQueryRequest:IRequest<List<GetFullListEmployeeQueryResponse>>
	{
	}
}
