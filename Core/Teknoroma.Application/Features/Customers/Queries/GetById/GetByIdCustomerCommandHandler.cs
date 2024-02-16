using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Customers.Queries.GetById
{
	public class GetByIdCustomerCommandHandler:IRequestHandler<GetByIdCustomerCommandRequest, GetByIdCustomerCommandResponse>
	{
		private readonly IMapper _mapper;
		private readonly ICustomerRepository _customerRepository;

		public GetByIdCustomerCommandHandler(IMapper mapper, ICustomerRepository customerRepository)
		{
			_mapper = mapper;
			_customerRepository = customerRepository;
		}

		public async Task<GetByIdCustomerCommandResponse> Handle(GetByIdCustomerCommandRequest request, CancellationToken cancellationToken)
		{
			Customer customer = await _customerRepository.GetAsync(x => x.ID == request.ID);

			GetByIdCustomerCommandResponse response = _mapper.Map<GetByIdCustomerCommandResponse>(customer);

			return response;
		}
	}
}
