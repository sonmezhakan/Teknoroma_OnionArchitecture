using System.Linq.Expressions;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Services.OrderDetails
{
    public class OrderDetailManager : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailManager(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task AddAsync(OrderDetail orderDetail)
        {
            await _orderDetailRepository.AddAsync(orderDetail);
        }

        public async Task AddRangeAsync(List<OrderDetail> orderDetails)
        {
            await _orderDetailRepository.AddRangeAsync(orderDetails);
        }

        public async Task<bool> AnyAsync(Expression<Func<OrderDetail, bool>> filter)
        {
            var result = await _orderDetailRepository.AnyAsync(filter);

            return result;
        }

        public async Task DeleteAsync(OrderDetail orderDetail)
        {
            await _orderDetailRepository.DeleteAsync(orderDetail);
        }

        public async Task DeleteRangeAsync(List<OrderDetail> orderDetails)
        {
            await _orderDetailRepository.DeleteRangeAsync(orderDetails);
        }

        public async Task<IQueryable<OrderDetail>> GetAllAsync(Expression<Func<OrderDetail, bool>> filter = null)
        {
            var result = await _orderDetailRepository.GetAllAsync(filter);

            return result;
        }

        public async Task<OrderDetail> GetAsync(Expression<Func<OrderDetail, bool>> filter)
        {
            var result = await _orderDetailRepository.GetAsync(filter);

            return result;
        }

        public async Task UpdateAsync(OrderDetail orderDetail)
        {
            await _orderDetailRepository.UpdateAsync(orderDetail);
        }

        public async Task UpdateRangeAsync(List<OrderDetail> orderDetails)
        {
            await _orderDetailRepository.UpdateRangeAsync(orderDetails);
        }
    }
}
