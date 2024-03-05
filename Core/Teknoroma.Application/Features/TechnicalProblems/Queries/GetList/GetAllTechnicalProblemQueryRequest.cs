using MediatR;

namespace Teknoroma.Application.Features.TechnicalProblems.Queries.GetList
{
    public class GetAllTechnicalProblemQueryRequest:IRequest<List<GetAllTechnicalProblemQueryResponse>>
    {
    }
}
