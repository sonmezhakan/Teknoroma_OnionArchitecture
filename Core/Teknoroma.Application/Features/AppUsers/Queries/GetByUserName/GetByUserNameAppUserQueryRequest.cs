using MediatR;


namespace Teknoroma.Application.Features.AppUsers.Queries.GetByUserName
{
    public class GetByUserNameAppUserQueryRequest:IRequest<GetByUserNameAppUserQueryResponse>
    {
        public string UserName { get; set; }
    }
}
