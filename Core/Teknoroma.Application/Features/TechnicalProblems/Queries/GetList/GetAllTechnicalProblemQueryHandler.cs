using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.TechnicalProblems;

namespace Teknoroma.Application.Features.TechnicalProblems.Queries.GetList
{
	public class GetAllTechnicalProblemQueryHandler : IRequestHandler<GetAllTechnicalProblemQueryRequest, List<GetAllTechnicalProblemQueryResponse>>
    {
        private readonly IMapper _mapper;
		private readonly ITechnicalProblemService _technicalProblemService;

		public GetAllTechnicalProblemQueryHandler(IMapper mapper, ITechnicalProblemService technicalProblemService)
        {
            _mapper = mapper;
			_technicalProblemService = technicalProblemService;
		}
        public async Task<List<GetAllTechnicalProblemQueryResponse>> Handle(GetAllTechnicalProblemQueryRequest request, CancellationToken cancellationToken)
        {
            var technicalProblems = await _technicalProblemService.GetAllAsync();

            List<GetAllTechnicalProblemQueryResponse> getAllTechnicalProblemQueryResponses = _mapper.Map<List<GetAllTechnicalProblemQueryResponse>>(technicalProblems.ToList());

            return getAllTechnicalProblemQueryResponses;
        }
    }
}
