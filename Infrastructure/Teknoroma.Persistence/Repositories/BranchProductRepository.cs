using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;
using Teknoroma.Domain.Interfaces;
using Teknoroma.Persistence.Context;

namespace Teknoroma.Persistence.Repositories
{
    public class BranchProductRepository : BaseRepository<BranchProduct>, IBranchProductRepository
    {
        public BranchProductRepository(TeknoromaContext context) : base(context)
        {

        }

    }
}
