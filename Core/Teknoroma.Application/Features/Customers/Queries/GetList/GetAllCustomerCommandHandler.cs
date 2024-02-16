using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Repositories;

namespace Teknoroma.Application.Features.Customers.Queries.GetList
{
	public class GetAllCustomerCommandHandler:IRequestHandler<GetAllCustomerCommandRequest, List<GetAllCustomerCommandResponse>>
	{
		private readonly IMapper _mapper;
		private readonly ICustomerRepository _customerRepository;

		public GetAllCustomerCommandHandler(IMapper mapper, ICustomerRepository customerRepository)
		{
			_mapper = mapper;
			_customerRepository = customerRepository;
		}

		public async Task<List<GetAllCustomerCommandResponse>> Handle(GetAllCustomerCommandRequest request, CancellationToken cancellationToken)
		{
			var customers = await _customerRepository.GetAllAsync();

			List<GetAllCustomerCommandResponse> responses = _mapper.Map<List<GetAllCustomerCommandResponse>>(customers);

			return responses;
		}
	}
}
