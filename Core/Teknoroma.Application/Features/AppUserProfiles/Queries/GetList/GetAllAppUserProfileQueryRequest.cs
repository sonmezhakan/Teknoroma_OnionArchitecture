using MediatR;

namespace Teknoroma.Application.Features.AppUserProfiles.Quıeries.GetList
{
    public class GetAllAppUserProfileQueryRequest:IRequest<List<GetAllAppUserProfileQueryResponse>>
    {
    }
}
