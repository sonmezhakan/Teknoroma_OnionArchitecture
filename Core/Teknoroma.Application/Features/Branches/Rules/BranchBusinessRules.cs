using Teknoroma.Application.Exceptions.Types;
using Teknoroma.Application.Features.Branches.Constants;
using Teknoroma.Application.Repositories;

namespace Teknoroma.Application.Features.Branches.Rules
{
    public class BranchBusinessRules
	{
		private readonly IBranchRepository _branchRepository;

		public BranchBusinessRules(IBranchRepository branchRepository)
        {
			_branchRepository = branchRepository;
		}

		public async Task BranchNameCannotBeDuplicatedWhenInserted(string branchName)
		{
			bool result = await _branchRepository.AnyAsync(x => x.BranchName == branchName);

			if (result)
				throw new BusinessException(BranchesMessages.BranchNameExists);
		}

		public async Task BranchNameCannotBeDuplicatedWhenUpdated(string oldBranchName,string newBranchName)
		{
			if (oldBranchName != newBranchName)
			{
				bool result = await _branchRepository.AnyAsync(x => x.BranchName == newBranchName);

				if (result)
					throw new BusinessException(BranchesMessages.BranchNameExists);
			}
			
		}

		public async Task PhoneNumberCannotBeDuplicatedWhenInserted(string? phoneNumber)
		{
			if(phoneNumber != null)
			{
                bool result = await _branchRepository.AnyAsync(x => x.PhoneNumber == phoneNumber);

                if (result)
                    throw new BusinessException(BranchesMessages.PhoneNumberExists);
            }
		}

		public async Task PhoneNumberCannotBeDuplicatedWhenUpdated(string oldPhoneNumber, string newPhoneNumber)
		{
			if(oldPhoneNumber != newPhoneNumber)
			{
				bool result = await _branchRepository.AnyAsync(x => x.PhoneNumber == newPhoneNumber);

				if (result)
					throw new BusinessException(BranchesMessages.PhoneNumberExists);
			}	
		}
	}
}
