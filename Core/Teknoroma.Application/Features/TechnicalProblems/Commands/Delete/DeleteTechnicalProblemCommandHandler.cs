using MediatR;
using Teknoroma.Application.Services.TechnicalProblems;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.TechnicalProblems.Commands.Delete
{
	public class DeleteTechnicalProblemCommandHandler : IRequestHandler<DeleteTechnicalProblemCommandRequest, Unit>
    {
		private readonly ITechnicalProblemService _technicalProblemService;

		public DeleteTechnicalProblemCommandHandler(ITechnicalProblemService technicalProblemService)
        {
			_technicalProblemService = technicalProblemService;
		}
        public async Task<Unit> Handle(DeleteTechnicalProblemCommandRequest request, CancellationToken cancellationToken)
        {
            TechnicalProblem technicalProblem = await _technicalProblemService.GetAsync(x => x.ID == request.ID);

            await _technicalProblemService.DeleteAsync(technicalProblem);

            return Unit.Value;
        }
    }
}
