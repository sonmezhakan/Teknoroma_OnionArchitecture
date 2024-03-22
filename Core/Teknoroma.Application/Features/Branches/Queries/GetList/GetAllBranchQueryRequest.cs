using MediatR;
using System.Linq.Expressions;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Branches.Queries.GetAll
{
    public class GetAllBranchQueryRequest:IRequest<List<GetAllBranchQueryResponse>>
	{
    }
}
