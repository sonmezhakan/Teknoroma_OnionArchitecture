using AutoMapper;
using MediatR;
using Teknoroma.Application.Features.Branches.Rules;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Branches.Command.Update
{
	public class UpdateBranchCommadHandler : IRequestHandler<UpdateBranchCommandRequest, Unit>
	{
		private readonly IMapper _mapper;
		private readonly IBranchRepository _branchRepository;
		private readonly BranchBusinessRules _branchBusinessRules;

		public UpdateBranchCommadHandler(IMapper mapper, IBranchRepository branchRepository,BranchBusinessRules branchBusinessRules)
        {
			_mapper = mapper;
			_branchRepository = branchRepository;
			_branchBusinessRules = branchBusinessRules;
		}

        public async Task<Unit> Handle(UpdateBranchCommandRequest request, CancellationToken cancellationToken)
		{
			Branch branch = await _branchRepository.GetAsync(x => x.ID == request.ID);

			//BusinesRules
			await _branchBusinessRules.UpdateBranchNameCannotBeDuplicatedWhenInserted(branch.BranchName,request.BranchName);
			await _branchBusinessRules.UpdatePhoneNumberCannotBeDuplicatedWhenInserted(branch.PhoneNumber,request.PhoneNumber);

			branch = _mapper.Map(request, branch);

			await _branchRepository.UpdateAsync(branch);

			return Unit.Value;
		}
	}
}
