using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.TechnicalProblems;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.TechnicalProblems.Commands.Update
{
	public class UpdateTechnicalProblemCommandHandler : IRequestHandler<UpdateTechnicalProblemCommandRequest, Unit>
    {
        private readonly IMapper _mapper;
		private readonly ITechnicalProblemService _technicalProblemService;

		public UpdateTechnicalProblemCommandHandler(IMapper mapper,ITechnicalProblemService technicalProblemService)
        {
            _mapper = mapper;
			_technicalProblemService = technicalProblemService;
		}
        public async Task<Unit> Handle(UpdateTechnicalProblemCommandRequest request, CancellationToken cancellationToken)
        {
            TechnicalProblem technicalProblem = await _technicalProblemService.GetAsync(x => x.ID == request.ID);

            technicalProblem = _mapper.Map(request, technicalProblem);

            await _technicalProblemService.UpdateAsync(technicalProblem);

            return Unit.Value;
        }
    }
}
