using Nexus.Core.API.Models;

namespace Nexus.Core.API.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order> CreateAsync(Order order);
    }
}