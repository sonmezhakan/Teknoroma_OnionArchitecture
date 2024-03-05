using AutoMapper;
using MediatR;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.TechnicalProblems.Commands.Create
{
    public class CreateTechnicalProblemCommandHandler : IRequestHandler<CreateTechnicalProblemCommandRequest, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ITechnicalProblemRepository _technicalProblemRepository;

        public CreateTechnicalProblemCommandHandler(IMapper mapper,ITechnicalProblemRepository technicalProblemRepository)
        {
            _mapper = mapper;
            _technicalProblemRepository = technicalProblemRepository;
        }
        public async Task<Unit> Handle(CreateTechnicalProblemCommandRequest request, CancellationToken cancellationToken)
        {
            TechnicalProblem technicalProblem = _mapper.Map<TechnicalProblem>(request);

            await _technicalProblemRepository.AddAsync(technicalProblem);

            return Unit.Value;
        }
    }
}
