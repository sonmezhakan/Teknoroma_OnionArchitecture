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

namespace Teknoroma.Application.Features.Customers.Command.Update
{
	public class UpdateCustomerCommandHandler:IRequestHandler<UpdateCustomerCommandRequest, Unit>
	{
		private readonly IMapper _mapper;
		private readonly ICustomerRepository _customerRepository;
		private readonly CustomerBusinessRules _customerBusinessRules;

		public UpdateCustomerCommandHandler(IMapper mapper, ICustomerRepository customerRepository,CustomerBusinessRules customerBusinessRules)
		{
			_mapper = mapper;
			_customerRepository = customerRepository;
			_customerBusinessRules = customerBusinessRules;
		}

		public async Task<Unit> Handle(UpdateCustomerCommandRequest request, CancellationToken cancellationToken)
		{
			Customer customer = await _customerRepository.GetAsync(x => x.ID == request.ID);

			//BusinessRules
			await _customerBusinessRules.PhoneNumberCannotBeDuplicatedWhenUpdated(customer.PhoneNumber,request.PhoneNumber);

			customer = _mapper.Map(request, customer);

			await _customerRepository.UpdateAsync(customer);

			return Unit.Value;
		}
	}
}
