using MediatR;

namespace Teknoroma.Application.Features.AppUsers.Queries.GetListSelectIdAndName
{
    public class GetAllSelectIdAndNameAppUserQueryRequest:IRequest<List<GetAllSelectIdAndNameAppUserQueryResponse>>
    {
    }
}
