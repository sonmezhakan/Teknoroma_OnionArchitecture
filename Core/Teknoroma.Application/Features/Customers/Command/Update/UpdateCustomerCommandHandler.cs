using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Customers.Command.Update
{
	public class UpdateCustomerCommandHandler:IRequestHandler<UpdateCustomerCommandRequest,string>
	{
		private readonly IMapper _mapper;
		private readonly ICustomerRepository _customerRepository;

		public UpdateCustomerCommandHandler(IMapper mapper, ICustomerRepository customerRepository)
		{
			_mapper = mapper;
			_customerRepository = customerRepository;
		}

		public async Task<string> Handle(UpdateCustomerCommandRequest request, CancellationToken cancellationToken)
		{
			Customer customer = await _customerRepository.GetAsync(x => x.ID == request.ID);

			customer = _mapper.Map(request, customer);

			await _customerRepository.UpdateAsync(customer);

			return "Güncelleme Başarılı!";
		}
	}
}
