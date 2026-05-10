using MediatR;
using Nexus.Core.API.Models;

namespace Nexus.Core.API.Orders.Commands
{
    public class CreateOrderCommand : IRequest<Order>
    {
        public string OrderName { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
    }
}