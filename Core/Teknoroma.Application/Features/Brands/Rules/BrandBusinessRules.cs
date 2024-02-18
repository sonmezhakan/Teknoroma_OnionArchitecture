using Teknoroma.Application.Exceptions.Types;
using Teknoroma.Application.Features.Branches.Constants;
using Teknoroma.Application.Features.Brands.Contants;
using Teknoroma.Application.Repositories;

namespace Teknoroma.Application.Features.Brands.Rules
{
    public class BrandBusinessRules
	{
        private readonly IBrandRepository _brandRepository;

        public BrandBusinessRules(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task BrandNameCannotBeDuplicatedWhenInserted(string name)
        {
            bool result = await _brandRepository.AnyAsync(x => x.BrandName == name);

            if(result)
				throw new BusinessException(BrandsMessages.BrandNameExists);
		}
		public async Task UpdateBrandNameCannotBeDuplicatedWhenInserted(string oldBrandName, string newBrandName)
		{
			if(oldBrandName != newBrandName)
			{
				bool result = await _brandRepository.AnyAsync(x => x.BrandName == newBrandName);

				if (result)
					throw new BusinessException(BrandsMessages.BrandNameExists);
			}
		}

		public async Task PhoneNumberCannotBeDuplicatedWhenInserted(string phoneNumber)
		{
			bool result = await _brandRepository.AnyAsync(x => x.PhoneNumber == phoneNumber);

			if (result)
				throw new BusinessException(BrandsMessages.PhoneNumberExists);
		}

		public async Task UpdatePhoneNumberCannotBeDuplicatedWhenInserted(string oldPhoneNumber, string newPhoneNumber)
		{
			if (oldPhoneNumber != newPhoneNumber)
			{
				bool result = await _brandRepository.AnyAsync(x => x.PhoneNumber == newPhoneNumber);

				if (result)
					throw new BusinessException(BrandsMessages.PhoneNumberExists);
			}
		}
	}
}
