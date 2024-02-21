using MediatR;

namespace Teknoroma.Application.Features.AppUsers.Queries.GetList
{
    public class GetAllAppUserQueryRequest:IRequest<List<GetAllAppUserQueryResponse>>
    {
    }
}
