using MediatR;

namespace Teknoroma.Application.Features.AppUserProfiles.Quıeries.GetById
{
    public class GetByIdAppUserProfileQueryRequest:IRequest<GetByIdAppUserProfileQueryResponse>
    {
        public Guid ID { get; set; }
    }
}
