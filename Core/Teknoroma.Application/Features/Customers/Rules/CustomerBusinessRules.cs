using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Exceptions.Types;
using Teknoroma.Application.Features.Brands.Contants;
using Teknoroma.Application.Features.Customers.Contants;
using Teknoroma.Application.Repositories;

namespace Teknoroma.Application.Features.Customers.Rules
{
	public class CustomerBusinessRules
	{
		private readonly ICustomerRepository _customerRepository;

		public CustomerBusinessRules(ICustomerRepository customerRepository)
        {
			_customerRepository = customerRepository;
		}

		public async Task PhoneNumberCannotBeDuplicatedWhenInserted(string phoneNumber)
		{
			bool result = await _customerRepository.AnyAsync(x => x.PhoneNumber == phoneNumber);

			if (result)
				throw new BusinessException(CustomersMessages.PhoneNumberExists);
		}

		public async Task UpdatePhoneNumberCannotBeDuplicatedWhenInserted(string oldPhoneNumber, string newPhoneNumber)
		{
			if (oldPhoneNumber != newPhoneNumber)
			{
				bool result = await _customerRepository.AnyAsync(x => x.PhoneNumber == newPhoneNumber);

				if (result)
					throw new BusinessException(CustomersMessages.PhoneNumberExists);
			}
		}
	}
}
