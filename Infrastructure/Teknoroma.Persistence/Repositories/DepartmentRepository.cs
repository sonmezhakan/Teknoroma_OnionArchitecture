using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;
using Teknoroma.Persistence.Context;

namespace Teknoroma.Persistence.Repositories
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        private readonly TeknoromaContext _context;

        public DepartmentRepository(TeknoromaContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IQueryable<Department>> GetAllSelectIdAndNameAsync()
        {
            IQueryable<Department> query = _context.Departments.Where(x => x.IsActive).Select(x => new Department
            {
                ID = x.ID,
                DepartmentName = x.DepartmentName
            });
            return query;
        }
    }
}
