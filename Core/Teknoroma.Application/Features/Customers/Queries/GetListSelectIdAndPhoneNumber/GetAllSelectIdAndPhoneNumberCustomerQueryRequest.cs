using MediatR;

namespace Teknoroma.Application.Features.Customers.Queries.GetListSelectIdAndPhoneNumber
{
    public class GetAllSelectIdAndPhoneNumberCustomerQueryRequest:IRequest<List<GetAllSelectIdAndPhoneNumberCustomerQueryResponse>>
    {
    }
}
