using AutoMapper;
using MediatR;
using Teknoroma.Application.Features.Customers.Rules;
using Teknoroma.Application.Services.Customers;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Customers.Command.Create
{
	public class CreateCustomerCommandHandler:IRequestHandler<CreateCustomerCommandRequest, Unit>
	{
		private readonly IMapper _mapper;
		private readonly ICustomerService _customerService;
		private readonly CustomerBusinessRules _customerBusinessRules;

		public CreateCustomerCommandHandler(IMapper mapper,ICustomerService customerService,CustomerBusinessRules customerBusinessRules)
        {
			_mapper = mapper;
			_customerService = customerService;
			_customerBusinessRules = customerBusinessRules;
		}

		public async Task<Unit> Handle(CreateCustomerCommandRequest request, CancellationToken cancellationToken)
		{
			//BusinessRules
			await _customerBusinessRules.PhoneNumberCannotBeDuplicatedWhenInserted(request.PhoneNumber);

			Customer customer = _mapper.Map<Customer>(request);

			await _customerService.AddAsync(customer);

			return Unit.Value;
		}
	}
}
