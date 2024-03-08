using MediatR;
using Teknoroma.Application.Services.Branches;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Branches.Command.Delete
{
	public class DeleteBranchCommandHandler : IRequestHandler<DeleteBranchCommandRequest, Unit>
	{
		private readonly IBranchService _branchService;

		public DeleteBranchCommandHandler(IBranchService branchService)
        {
			_branchService = branchService;
		}
        public async Task<Unit> Handle(DeleteBranchCommandRequest request, CancellationToken cancellationToken)
		{
			Branch branch = await _branchService.GetAsync(x=>x.ID == request.ID);

			await _branchService.DeleteAsync(branch);

			return Unit.Value;
		}
	}
}
