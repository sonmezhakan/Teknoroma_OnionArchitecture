using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;
using Teknoroma.Persistence.Context;

namespace Teknoroma.Persistence.Repositories
{
    public class TechnicalProblemRepository : BaseRepository<TechnicalProblem>, ITechnicalProblemRepository
    {
        public TechnicalProblemRepository(TeknoromaContext context) : base(context)
        {
        }
    }
}
