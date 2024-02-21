using MediatR;

namespace Teknoroma.Application.Features.AppUserRoles.Queries.GetById
{
    public class GetByIdAppUserRoleQueryRequest:IRequest<GetByIdAppUserRoleQueryResponse>
    {
        public Guid ID { get; set; }
    }
}
