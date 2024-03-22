using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Services.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<IQueryable<Product>> GetAllSelectIdAndNameAsync();
    }
}
