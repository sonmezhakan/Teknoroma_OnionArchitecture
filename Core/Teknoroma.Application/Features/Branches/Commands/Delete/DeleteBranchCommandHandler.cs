using AutoMapper;
using MediatR;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Branches.Command.Delete
{
	public class DeleteBranchCommandHandler : IRequestHandler<DeleteBranchCommandRequest, Unit>
	{
		private readonly IBranchRepository _branchRepository;

		public DeleteBranchCommandHandler(IBranchRepository branchRepository)
        {
			_branchRepository = branchRepository;
		}
        public async Task<Unit> Handle(DeleteBranchCommandRequest request, CancellationToken cancellationToken)
		{
			Branch branch = await _branchRepository.GetAsync(x=>x.ID == request.ID);

			await _branchRepository.DeleteAsync(branch);

			return Unit.Value;
		}
	}
}
