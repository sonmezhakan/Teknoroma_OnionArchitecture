using MediatR;

namespace Teknoroma.Application.Features.Orders.Queries.GetByBranchIdList
{
    public class GetByBranchIdOrderListQueryRequest : IRequest<List<GetByBranchIdOrderListQueryResponse>>
    {
        public Guid BranchId { get; set; }
    }
}
