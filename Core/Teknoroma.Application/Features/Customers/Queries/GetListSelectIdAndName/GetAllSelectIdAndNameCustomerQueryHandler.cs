using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Repositories;

namespace Teknoroma.Application.Features.Customers.Queries.GetListSelectIdAndName
{
    public class GetAllSelectIdAndNameCustomerQueryHandler : IRequestHandler<GetAllSelectIdAndNameCustomerQueryRequest, List<GetAllSelectIdAndNameCustomerQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public GetAllSelectIdAndNameCustomerQueryHandler(IMapper mapper,ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }
        public async Task<List<GetAllSelectIdAndNameCustomerQueryResponse>> Handle(GetAllSelectIdAndNameCustomerQueryRequest request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetAllSelectIdAndNameAsync();

            List<GetAllSelectIdAndNameCustomerQueryResponse> getAllSelectIdAndNameCustomerQueryResponses = _mapper.Map<List<GetAllSelectIdAndNameCustomerQueryResponse>>(customers.ToList());

            return getAllSelectIdAndNameCustomerQueryResponses;
        }
    }
}
