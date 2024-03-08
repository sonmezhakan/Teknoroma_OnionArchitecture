using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;
using Teknoroma.Persistence.Context;

namespace Teknoroma.Persistence.Repositories
{

    public class BranchRepository : BaseRepository<Branch>, IBranchRepository
    {
        public BranchRepository(TeknoromaContext context) : base(context)
        {

        }
    }
}
