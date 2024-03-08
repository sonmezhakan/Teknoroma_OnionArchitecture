using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.TechnicalProblems.Queries.GetById
{
    public class GetByIdTechnicalProblemQueryHandler : IRequestHandler<GetByIdTechnicalProblemQueryRequest, GetByIdTechnicalProblemQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITechnicalProblemRepository _technicalProblemRepository;

        public GetByIdTechnicalProblemQueryHandler(IMapper mapper, ITechnicalProblemRepository technicalProblemRepository)
        {
            _mapper = mapper;
            _technicalProblemRepository = technicalProblemRepository;
        }
        public async Task<GetByIdTechnicalProblemQueryResponse> Handle(GetByIdTechnicalProblemQueryRequest request, CancellationToken cancellationToken)
        {
            TechnicalProblem technicalProblem = await _technicalProblemRepository.GetAsync(x => x.ID == request.ID);

            GetByIdTechnicalProblemQueryResponse getByIdTechnicalProblemQueryResponse = _mapper.Map<GetByIdTechnicalProblemQueryResponse>(technicalProblem);

            return getByIdTechnicalProblemQueryResponse;
        }
    }
}
