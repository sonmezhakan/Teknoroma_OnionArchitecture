using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Customers.Command.Create
{
	public class CreateCustomerCommandHandler:IRequestHandler<CreateCustomerCommandRequest,string>
	{
		private readonly IMapper _mapper;
		private readonly ICustomerRepository _customerRepository;

		public CreateCustomerCommandHandler(IMapper mapper,ICustomerRepository customerRepository)
        {
			_mapper = mapper;
			_customerRepository = customerRepository;
		}

		public async Task<string> Handle(CreateCustomerCommandRequest request, CancellationToken cancellationToken)
		{
			Customer customer = _mapper.Map<Customer>(request);

			await _customerRepository.AddAsync(customer);

			return "Kayıt Başarılı!";
		}
	}
}
