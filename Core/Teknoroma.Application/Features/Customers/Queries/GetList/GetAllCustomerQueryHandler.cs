using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Repositories;

namespace Teknoroma.Application.Features.Customers.Queries.GetList
{
	public class GetAllCustomerQueryHandler:IRequestHandler<GetAllCustomerQueryRequest, List<GetAllCustomerQueryResponse>>
	{
		private readonly IMapper _mapper;
		private readonly ICustomerRepository _customerRepository;

		public GetAllCustomerQueryHandler(IMapper mapper, ICustomerRepository customerRepository)
		{
			_mapper = mapper;
			_customerRepository = customerRepository;
		}

		public async Task<List<GetAllCustomerQueryResponse>> Handle(GetAllCustomerQueryRequest request, CancellationToken cancellationToken)
		{
			var customers = await _customerRepository.GetAllAsync();

			List<GetAllCustomerQueryResponse> responses = _mapper.Map<List<GetAllCustomerQueryResponse>>(customers.ToList());

			return responses;
		}
	}
}
