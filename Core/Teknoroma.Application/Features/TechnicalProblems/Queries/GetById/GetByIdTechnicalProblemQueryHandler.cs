using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.TechnicalProblems;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.TechnicalProblems.Queries.GetById
{
	public class GetByIdTechnicalProblemQueryHandler : IRequestHandler<GetByIdTechnicalProblemQueryRequest, GetByIdTechnicalProblemQueryResponse>
    {
        private readonly IMapper _mapper;
		private readonly ITechnicalProblemService _technicalProblemService;

		public GetByIdTechnicalProblemQueryHandler(IMapper mapper, ITechnicalProblemService technicalProblemService)
        {
            _mapper = mapper;
			_technicalProblemService = technicalProblemService;
		}
        public async Task<GetByIdTechnicalProblemQueryResponse> Handle(GetByIdTechnicalProblemQueryRequest request, CancellationToken cancellationToken)
        {
            TechnicalProblem technicalProblem = await _technicalProblemService.GetAsync(x => x.ID == request.ID);

            GetByIdTechnicalProblemQueryResponse getByIdTechnicalProblemQueryResponse = _mapper.Map<GetByIdTechnicalProblemQueryResponse>(technicalProblem);

            return getByIdTechnicalProblemQueryResponse;
        }
    }
}
