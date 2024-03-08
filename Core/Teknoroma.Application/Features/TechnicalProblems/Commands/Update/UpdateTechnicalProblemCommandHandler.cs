using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.TechnicalProblems.Commands.Update
{
    public class UpdateTechnicalProblemCommandHandler : IRequestHandler<UpdateTechnicalProblemCommandRequest, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ITechnicalProblemRepository _technicalProblemRepository;

        public UpdateTechnicalProblemCommandHandler(IMapper mapper,ITechnicalProblemRepository technicalProblemRepository)
        {
            _mapper = mapper;
            _technicalProblemRepository = technicalProblemRepository;
        }
        public async Task<Unit> Handle(UpdateTechnicalProblemCommandRequest request, CancellationToken cancellationToken)
        {
            TechnicalProblem technicalProblem = await _technicalProblemRepository.GetAsync(x => x.ID == request.ID);

            technicalProblem = _mapper.Map(request, technicalProblem);

            await _technicalProblemRepository.UpdateAsync(technicalProblem);

            return Unit.Value;
        }
    }
}
