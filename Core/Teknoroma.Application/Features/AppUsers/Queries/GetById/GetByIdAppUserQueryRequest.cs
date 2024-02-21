using MediatR;

namespace Teknoroma.Application.Features.AppUsers.Queries.GetById
{
    public class GetByIdAppUserQueryRequest:IRequest<GetByIdAppUserQueryResponse>
    {
        public Guid ID { get; set; }
    }
}
