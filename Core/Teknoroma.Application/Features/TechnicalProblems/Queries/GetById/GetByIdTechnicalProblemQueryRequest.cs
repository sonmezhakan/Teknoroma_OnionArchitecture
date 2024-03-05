using MediatR;

namespace Teknoroma.Application.Features.TechnicalProblems.Queries.GetById
{
    public class GetByIdTechnicalProblemQueryRequest:IRequest<GetByIdTechnicalProblemQueryResponse>
    {
        public Guid ID { get; set; }
    }
}
