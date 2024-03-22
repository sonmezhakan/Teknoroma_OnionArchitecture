using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;
using Teknoroma.Domain.Interfaces;
using Teknoroma.Persistence.Context;

namespace Teknoroma.Persistence.Repositories
{

    public class BranchRepository : BaseRepository<Branch>, IBranchRepository
    {
        private readonly TeknoromaContext _context;

        public BranchRepository(TeknoromaContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IQueryable<Branch>> GetAllSelectIdAndNameAsync()
        {
            IQueryable<Branch> query = _context.Branches.Where(x=>x.IsActive).Select(x=> new Branch {
            ID = x.ID,
            BranchName = x.BranchName
            });
            return query;
        }
    }
}
