using MediatR;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.TechnicalProblems.Commands.Delete
{
	public class DeleteTechnicalProblemCommandHandler : IRequestHandler<DeleteTechnicalProblemCommandRequest, Unit>
    {
		private readonly ITechnicalProblemRepository _technicalProblemRepository;

		public DeleteTechnicalProblemCommandHandler(ITechnicalProblemRepository technicalProblemRepository)
        {
			_technicalProblemRepository = technicalProblemRepository;
		}
        public async Task<Unit> Handle(DeleteTechnicalProblemCommandRequest request, CancellationToken cancellationToken)
        {
            TechnicalProblem technicalProblem = await _technicalProblemRepository.GetAsync(x => x.ID == request.ID);

            await _technicalProblemRepository.DeleteAsync(technicalProblem);

            return Unit.Value;
        }
    }
}
