using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;
using Teknoroma.Persistence.Context;

namespace Teknoroma.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly TeknoromaContext _context;

        public CategoryRepository(TeknoromaContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IQueryable<Category>> GetAllSelectIdAndNameAsync()
        {
            IQueryable<Category> query = _context.Categories.Where(x => x.IsActive).Select(x => new Category
            {
                ID = x.ID,
                CategoryName = x.CategoryName
            });
            return query;
        }
    }
}
