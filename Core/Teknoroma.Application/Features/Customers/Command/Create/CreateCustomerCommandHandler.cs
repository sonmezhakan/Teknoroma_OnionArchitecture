using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Features.Customers.Rules;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Customers.Command.Create
{
	public class CreateCustomerCommandHandler:IRequestHandler<CreateCustomerCommandRequest, Unit>
	{
		private readonly IMapper _mapper;
		private readonly ICustomerRepository _customerRepository;
		private readonly CustomerBusinessRules _customerBusinessRules;

		public CreateCustomerCommandHandler(IMapper mapper,ICustomerRepository customerRepository,CustomerBusinessRules customerBusinessRules)
        {
			_mapper = mapper;
			_customerRepository = customerRepository;
			_customerBusinessRules = customerBusinessRules;
		}

		public async Task<Unit> Handle(CreateCustomerCommandRequest request, CancellationToken cancellationToken)
		{
			//BusinessRules
			await _customerBusinessRules.PhoneNumberCannotBeDuplicatedWhenInserted(request.PhoneNumber);

			Customer customer = _mapper.Map<Customer>(request);

			await _customerRepository.AddAsync(customer);

			return Unit.Value;
		}
	}
}
