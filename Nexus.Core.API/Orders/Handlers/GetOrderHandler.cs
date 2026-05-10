using MediatR;
using Nexus.Core.API.Models;
using Nexus.Core.API.Orders.Queries;
using Nexus.Core.API.Services;

namespace Nexus.Core.API.Orders.Handlers
{
    public class GetOrdersHandler : IRequestHandler<GetOrdersQuery, IEnumerable<Order>>
    {
        private readonly OrderService _orderService;

        public GetOrdersHandler(OrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IEnumerable<Order>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _orderService.GetAllOrdersAsync();
        }
    }
}