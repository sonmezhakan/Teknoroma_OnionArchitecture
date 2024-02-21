using Teknoroma.Application.Exceptions.Types;
using Teknoroma.Application.Features.Suppliers.Contants;
using Teknoroma.Application.Repositories;

namespace Teknoroma.Application.Features.Suppliers.Rules
{
	public class SupplierBusinessRules
	{
		private readonly ISupplierRepository _supplierRepository;

		public SupplierBusinessRules(ISupplierRepository supplierRepository)
		{
			_supplierRepository = supplierRepository;
		}
		public async Task PhoneNumberCannotBeDuplicatedWhenInserted(string? phoneNumber)
		{
			if(phoneNumber != null)
			{
                bool result = await _supplierRepository.AnyAsync(x => x.PhoneNumber == phoneNumber);

                if (result)
                    throw new BusinessException(SuppliersMessages.PhoneNumberExists);
            }
		}

		public async Task PhoneNumberCannotBeDuplicatedWhenUpdated(string oldPhoneNumber, string newPhoneNumber)
		{
			if (oldPhoneNumber != newPhoneNumber)
			{
				bool result = await _supplierRepository.AnyAsync(x => x.PhoneNumber == newPhoneNumber);

				if (result)
					throw new BusinessException(SuppliersMessages.PhoneNumberExists);
			}
		}
	}
}
