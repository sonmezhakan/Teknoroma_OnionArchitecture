using System.Linq.Expressions;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Services.Orders
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task AddAsync(Order order)
        {
            await _orderRepository.AddAsync(order);
        }

        public async Task AddRangeAsync(List<Order> orders)
        {
            await _orderRepository.AddRangeAsync(orders);
        }

        public async Task<bool> AnyAsync(Expression<Func<Order, bool>> filter)
        {
            var result = await _orderRepository.AnyAsync(filter);

            return result;
        }

        public async Task DeleteAsync(Order order)
        {
            await _orderRepository.DeleteAsync(order);
        }

        public async Task DeleteRangeAsync(List<Order> order)
        {
            await _orderRepository.DeleteRangeAsync(order);
        }

        public async Task<IQueryable<Order>> GetAllAsync(Expression<Func<Order, bool>> filter = null)
        {
            var result = await _orderRepository.GetAllAsync(filter);

            return result;
        }

        public async Task<Order> GetAsync(Expression<Func<Order, bool>> filter)
        {
            var result = await _orderRepository.GetAsync(filter);

            return result;
        }

        public async Task UpdateAsync(Order order)
        {
            await _orderRepository.UpdateAsync(order);
        }

        public async Task UpdateRangeAsync(List<Order> order)
        {
            await _orderRepository.UpdateRangeAsync(order);
        }
    }
}
