using MediatR;

namespace Teknoroma.Application.Features.Customers.Queries.GetCustomerEarningReport
{
    public class GetCustomerEarningReportQueryRequest : IRequest<List<GetCustomerEarningReportQueryResponse>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
