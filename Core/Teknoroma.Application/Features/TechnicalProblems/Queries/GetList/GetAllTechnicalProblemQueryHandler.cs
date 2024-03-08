using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Repositories;

namespace Teknoroma.Application.Features.TechnicalProblems.Queries.GetList
{
    public class GetAllTechnicalProblemQueryHandler : IRequestHandler<GetAllTechnicalProblemQueryRequest, List<GetAllTechnicalProblemQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ITechnicalProblemRepository _technicalProblemRepository;

        public GetAllTechnicalProblemQueryHandler(IMapper mapper, ITechnicalProblemRepository technicalProblemRepository)
        {
            _mapper = mapper;
            _technicalProblemRepository = technicalProblemRepository;
        }
        public async Task<List<GetAllTechnicalProblemQueryResponse>> Handle(GetAllTechnicalProblemQueryRequest request, CancellationToken cancellationToken)
        {
            var technicalProblems = await _technicalProblemRepository.GetAllAsync();

            List<GetAllTechnicalProblemQueryResponse> getAllTechnicalProblemQueryResponses = _mapper.Map<List<GetAllTechnicalProblemQueryResponse>>(technicalProblems.ToList());

            return getAllTechnicalProblemQueryResponses;
        }
    }
}
