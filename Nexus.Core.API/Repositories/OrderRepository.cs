using Nexus.Core.API.Models;

namespace Nexus.Core.API.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        // In-memory fake database
        private static readonly List<Order> _orders = new()
        {
            new Order { Id = 1, OrderName = "Order A", CustomerName = "Ali", TotalAmount = 500, CreatedAt = DateTime.UtcNow },
            new Order { Id = 2, OrderName = "Order B", CustomerName = "Sara", TotalAmount = 1200, CreatedAt = DateTime.UtcNow }
        };

        public Task<IEnumerable<Order>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Order>>(_orders);
        }

        public Task<Order> CreateAsync(Order order)
        {
            order.Id = _orders.Count + 1;
            _orders.Add(order);
            return Task.FromResult(order);
        }
    }
}