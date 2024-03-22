using MediatR;

namespace Teknoroma.Application.Features.Branches.Queries.GetListSelectIdAndName
{
    public class GetAllSelectIdAndNameBranchQueryRequest:IRequest<List<GetAllSelectIdAndNameBranchQueryResponse>>
    {
    }
}
