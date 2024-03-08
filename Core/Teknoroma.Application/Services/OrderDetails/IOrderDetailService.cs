using System.Linq.Expressions;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Services.OrderDetails
{
    public interface IOrderDetailService
    {
        Task<IQueryable<OrderDetail>> GetAllAsync(Expression<Func<OrderDetail, bool>> filter = null);
        Task<OrderDetail> GetAsync(Expression<Func<OrderDetail, bool>> filter);

        Task<bool> AnyAsync(Expression<Func<OrderDetail, bool>> filter);

        Task AddAsync(OrderDetail orderDetail);
        Task AddRangeAsync(List<OrderDetail> orderDetails);

        Task UpdateAsync(OrderDetail orderDetail);
        Task UpdateRangeAsync(List<OrderDetail> orderDetails);

        Task DeleteAsync(OrderDetail orderDetail);
        Task DeleteRangeAsync(List<OrderDetail> orderDetails);
    }
}
