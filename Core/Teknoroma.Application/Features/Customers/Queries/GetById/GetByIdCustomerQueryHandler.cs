using AutoMapper;
using MediatR;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Customers.Queries.GetById
{
	public class GetByIdCustomerQueryHandler:IRequestHandler<GetByIdCustomerQueryRequest, GetByIdCustomerQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly ICustomerRepository _customerRepository;

		public GetByIdCustomerQueryHandler(IMapper mapper, ICustomerRepository customerRepository)
		{
			_mapper = mapper;
			_customerRepository = customerRepository;
		}

		public async Task<GetByIdCustomerQueryResponse> Handle(GetByIdCustomerQueryRequest request, CancellationToken cancellationToken)
		{
			Customer customer = await _customerRepository.GetAsync(x => x.ID == request.ID);

			GetByIdCustomerQueryResponse response = _mapper.Map<GetByIdCustomerQueryResponse>(customer);

			return response;
		}
	}
}
