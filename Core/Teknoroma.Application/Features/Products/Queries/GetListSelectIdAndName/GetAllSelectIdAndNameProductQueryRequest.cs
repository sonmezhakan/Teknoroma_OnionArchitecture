using MediatR;

namespace Teknoroma.Application.Features.Products.Queries.GetListSelectIdAndName
{
    public class GetAllSelectIdAndNameProductQueryRequest : IRequest<List<GetAllSelectIdAndNameProductQueryResponse>>
    {
    }
}
