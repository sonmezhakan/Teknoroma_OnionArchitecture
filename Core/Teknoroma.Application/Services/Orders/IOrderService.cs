using System.Linq.Expressions;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Services.Orders
{
    public interface IOrderService
    {
        Task<IQueryable<Order>> GetAllAsync(Expression<Func<Order, bool>> filter = null);
        Task<Order> GetAsync(Expression<Func<Order, bool>> filter);

        Task<bool> AnyAsync(Expression<Func<Order, bool>> filter);

        Task AddAsync(Order order);
        Task AddRangeAsync(List<Order> orders);

        Task UpdateAsync(Order order);
        Task UpdateRangeAsync(List<Order> orders);

        Task DeleteAsync(Order order);
        Task DeleteRangeAsync(List<Order> orders);
    }
}
