using MediatR;
using Teknoroma.Application.Repositories;

namespace Teknoroma.Application.Features.Customers.Queries.GetCustomerSellingReport
{
    public class GetCustomerSellingReportQueryHandler : IRequestHandler<GetCustomerSellingReportQueryRequest, List<GetCustomerSellingReportQueryResponse>>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerSellingReportQueryHandler(ICustomerRepository customerRepository)
        {
           _customerRepository = customerRepository;
        }
        public Task<List<GetCustomerSellingReportQueryResponse>> Handle(GetCustomerSellingReportQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
