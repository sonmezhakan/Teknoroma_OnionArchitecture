using AutoMapper;
using MediatR;
using Teknoroma.Application.Features.Branches.Rules;
using Teknoroma.Application.Services.Branches;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Branches.Command.Update
{
	public class UpdateBranchCommadHandler : IRequestHandler<UpdateBranchCommandRequest, Unit>
	{
		private readonly IMapper _mapper;
		private readonly IBranchService _branchService;
		private readonly BranchBusinessRules _branchBusinessRules;

		public UpdateBranchCommadHandler(IMapper mapper, IBranchService branchService,BranchBusinessRules branchBusinessRules)
        {
			_mapper = mapper;
			_branchService = branchService;
			_branchBusinessRules = branchBusinessRules;
		}

        public async Task<Unit> Handle(UpdateBranchCommandRequest request, CancellationToken cancellationToken)
		{
			Branch branch = await _branchService.GetAsync(x => x.ID == request.ID);

			//BusinesRules
			await _branchBusinessRules.BranchNameCannotBeDuplicatedWhenUpdated(branch.BranchName,request.BranchName);
			await _branchBusinessRules.PhoneNumberCannotBeDuplicatedWhenUpdated(branch.PhoneNumber,request.PhoneNumber);

			branch = _mapper.Map(request, branch);

			await _branchService.UpdateAsync(branch);

			return Unit.Value;
		}
	}
}
