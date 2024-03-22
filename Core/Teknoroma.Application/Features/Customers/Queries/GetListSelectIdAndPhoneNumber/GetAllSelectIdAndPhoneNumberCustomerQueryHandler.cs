using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Customers.Queries.GetListSelectIdAndPhoneNumber
{
	public class GetAllSelectIdAndPhoneNumberCustomerQueryHandler : IRequestHandler<GetAllSelectIdAndPhoneNumberCustomerQueryRequest, List<GetAllSelectIdAndPhoneNumberCustomerQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public GetAllSelectIdAndPhoneNumberCustomerQueryHandler(IMapper mapper,ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }
        public async Task<List<GetAllSelectIdAndPhoneNumberCustomerQueryResponse>> Handle(GetAllSelectIdAndPhoneNumberCustomerQueryRequest request, CancellationToken cancellationToken)
        {
            
            var customers = await _customerRepository.GetAllSelectIdAndPhoneNumberAsync();

            List<GetAllSelectIdAndPhoneNumberCustomerQueryResponse> getAllSelectIdAndPhoneNumberCustomerQueryResponses = _mapper.Map<List<GetAllSelectIdAndPhoneNumberCustomerQueryResponse>>(customers.ToList());

            return getAllSelectIdAndPhoneNumberCustomerQueryResponses;
        }
    }
}
