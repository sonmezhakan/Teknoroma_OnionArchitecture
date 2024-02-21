using MediatR;

namespace Teknoroma.Application.Features.AppUserRoles.Queries.GetList
{
    public class GetAllAppUserRoleQueryRequest:IRequest<List<GetAllAppUserRoleQueryResponse>>
    {
    }
}
