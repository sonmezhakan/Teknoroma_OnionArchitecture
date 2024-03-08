using Teknoroma.Application.Exceptions.Types;
using Teknoroma.Application.Features.Customers.Contants;
using Teknoroma.Application.Services.Repositories;

namespace Teknoroma.Application.Features.Customers.Rules
{
    public class CustomerBusinessRules
	{
		private readonly ICustomerRepository _customerRepository;

		public CustomerBusinessRules(ICustomerRepository customerRepository)
        {
			_customerRepository = customerRepository;
		}

		public async Task PhoneNumberCannotBeDuplicatedWhenInserted(string? phoneNumber)
		{
			if(phoneNumber != null)
			{
                bool result = await _customerRepository.AnyAsync(x => x.PhoneNumber == phoneNumber);

                if (result)
                    throw new BusinessException(CustomersMessages.PhoneNumberExists);
            }
		}

		public async Task PhoneNumberCannotBeDuplicatedWhenUpdated(string oldPhoneNumber, string newPhoneNumber)
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
