using MediatR;

namespace Teknoroma.Application.Features.Customers.Queries.GetCustomerSellingReport
{
    public class GetCustomerSellingReportQueryRequest:IRequest<List<GetCustomerSellingReportQueryResponse>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
