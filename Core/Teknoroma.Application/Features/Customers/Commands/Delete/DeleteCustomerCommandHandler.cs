using MediatR;
using Teknoroma.Application.Services.Customers;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Customers.Command.Delete
{
	public class DeleteCustomerCommandHandler:IRequestHandler<DeleteCustomerCommandRequest, Unit>
	{
		private readonly ICustomerService _customerService;

		public DeleteCustomerCommandHandler(ICustomerService customerService)
        {
			_customerService = customerService;
		}

        public async Task<Unit> Handle(DeleteCustomerCommandRequest request, CancellationToken cancellationToken)
		{
			Customer customer = await _customerService.GetAsync(x => x.ID == request.ID);

			await _customerService.DeleteAsync(customer);

			return Unit.Value;
		}
	}
}
