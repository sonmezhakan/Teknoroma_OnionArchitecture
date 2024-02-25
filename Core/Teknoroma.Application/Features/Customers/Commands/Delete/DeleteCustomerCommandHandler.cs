using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Customers.Command.Delete
{
	public class DeleteCustomerCommandHandler:IRequestHandler<DeleteCustomerCommandRequest, Unit>
	{
		private readonly IMapper _mapper;
		private readonly ICustomerRepository _customerRepository;

		public DeleteCustomerCommandHandler(IMapper mapper, ICustomerRepository customerRepository)
		{
			_mapper = mapper;
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
