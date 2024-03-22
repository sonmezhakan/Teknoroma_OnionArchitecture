using MediatR;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Customers.Command.Delete
{
	public class DeleteCustomerCommandHandler:IRequestHandler<DeleteCustomerCommandRequest, Unit>
	{
		private readonly ICustomerRepository _customerRepository;

		public DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
        {
			_customerRepository = customerRepository;
		}

        public async Task<Unit> Handle(DeleteCustomerCommandRequest request, CancellationToken cancellationToken)
		{
			Customer customer = await _customerRepository.GetAsync(x => x.ID == request.ID);

			await _customerRepository.DeleteAsync(customer);

			return Unit.Value;
		}
	}
}
