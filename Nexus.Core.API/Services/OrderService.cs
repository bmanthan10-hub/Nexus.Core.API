using Nexus.Core.API.Models;
using Nexus.Core.API.Repositories;

namespace Nexus.Core.API.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            return await _repository.CreateAsync(order);
        }
    }
}