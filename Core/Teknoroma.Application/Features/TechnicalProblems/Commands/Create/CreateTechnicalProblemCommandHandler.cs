using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.TechnicalProblems;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.TechnicalProblems.Commands.Create
{
	public class CreateTechnicalProblemCommandHandler : IRequestHandler<CreateTechnicalProblemCommandRequest, Unit>
    {
        private readonly IMapper _mapper;
		private readonly ITechnicalProblemService _technicalProblemService;

		public CreateTechnicalProblemCommandHandler(IMapper mapper,ITechnicalProblemService technicalProblemService)
        {
            _mapper = mapper;
			_technicalProblemService = technicalProblemService;
		}
        public async Task<Unit> Handle(CreateTechnicalProblemCommandRequest request, CancellationToken cancellationToken)
        {
            TechnicalProblem technicalProblem = _mapper.Map<TechnicalProblem>(request);

            await _technicalProblemService.AddAsync(technicalProblem);

            return Unit.Value;
        }
    }
}
