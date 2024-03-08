using AutoMapper;
using MediatR;
using Teknoroma.Application.Features.Customers.Rules;
using Teknoroma.Application.Services.Customers;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Customers.Command.Update
{
	public class UpdateCustomerCommandHandler:IRequestHandler<UpdateCustomerCommandRequest, Unit>
	{
		private readonly IMapper _mapper;
		private readonly ICustomerService _customerService;
		private readonly CustomerBusinessRules _customerBusinessRules;

		public UpdateCustomerCommandHandler(IMapper mapper, ICustomerService customerService,CustomerBusinessRules customerBusinessRules)
		{
			_mapper = mapper;
			_customerService = customerService;
			_customerBusinessRules = customerBusinessRules;
		}

		public async Task<Unit> Handle(UpdateCustomerCommandRequest request, CancellationToken cancellationToken)
		{
			Customer customer = await _customerService.GetAsync(x => x.ID == request.ID);

			//BusinessRules
			await _customerBusinessRules.PhoneNumberCannotBeDuplicatedWhenUpdated(customer.PhoneNumber,request.PhoneNumber);

			customer = _mapper.Map(request, customer);

			await _customerService.UpdateAsync(customer);

			return Unit.Value;
		}
	}
}
