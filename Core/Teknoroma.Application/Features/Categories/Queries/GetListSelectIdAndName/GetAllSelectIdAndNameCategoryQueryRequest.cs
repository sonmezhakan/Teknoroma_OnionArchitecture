using MediatR;

namespace Teknoroma.Application.Features.Categories.Queries.GetListSelectIdAndName
{
    public class GetAllSelectIdAndNameCategoryQueryRequest:IRequest<List<GetAllSelectIdAndNameCategoryQueryResponse>>
    {
    }
}
