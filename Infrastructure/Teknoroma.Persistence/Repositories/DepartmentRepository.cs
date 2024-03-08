using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;
using Teknoroma.Persistence.Context;

namespace Teknoroma.Persistence.Repositories
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(TeknoromaContext context) : base(context)
        {
        }
    }
}
