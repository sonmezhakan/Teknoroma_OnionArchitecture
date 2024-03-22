using MediatR;

namespace Teknoroma.Application.Features.Customers.Queries.GetListSelectIdAndName
{
    public class GetAllSelectIdAndNameCustomerQueryRequest:IRequest<List<GetAllSelectIdAndNameCustomerQueryResponse>>
    {
    }
}
