using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Customers;

namespace Teknoroma.Application.Features.Customers.Queries.GetList
{
	public class GetAllCustomerQueryHandler:IRequestHandler<GetAllCustomerQueryRequest, List<GetAllCustomerQueryResponse>>
	{
		private readonly IMapper _mapper;
		private readonly ICustomerService _customerService;

		public GetAllCustomerQueryHandler(IMapper mapper, ICustomerService customerService)
		{
			_mapper = mapper;
			_customerService = customerService;
		}

		public async Task<List<GetAllCustomerQueryResponse>> Handle(GetAllCustomerQueryRequest request, CancellationToken cancellationToken)
		{
			var customers = await _customerService.GetAllAsync();

			List<GetAllCustomerQueryResponse> responses = _mapper.Map<List<GetAllCustomerQueryResponse>>(customers.ToList());

			return responses;
		}
	}
}
