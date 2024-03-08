using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Customers;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Customers.Queries.GetById
{
	public class GetByIdCustomerQueryHandler:IRequestHandler<GetByIdCustomerQueryRequest, GetByIdCustomerQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly ICustomerService _customerService;

		public GetByIdCustomerQueryHandler(IMapper mapper, ICustomerService customerService)
		{
			_mapper = mapper;
			_customerService = customerService;
		}

		public async Task<GetByIdCustomerQueryResponse> Handle(GetByIdCustomerQueryRequest request, CancellationToken cancellationToken)
		{
			Customer customer = await _customerService.GetAsync(x => x.ID == request.ID);

			GetByIdCustomerQueryResponse response = _mapper.Map<GetByIdCustomerQueryResponse>(customer);

			return response;
		}
	}
}
