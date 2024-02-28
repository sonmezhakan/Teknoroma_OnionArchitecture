using MediatR;

namespace Teknoroma.Application.Features.Customers.Queries.GetCustomerEarningReport
{
    public class GetCustomerEarningReportQueryHandler : IRequestHandler<GetCustomerEarningReportQueryRequest, List<GetCustomerEarningReportQueryResponse>>
    {
        public Task<List<GetCustomerEarningReportQueryResponse>> Handle(GetCustomerEarningReportQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
