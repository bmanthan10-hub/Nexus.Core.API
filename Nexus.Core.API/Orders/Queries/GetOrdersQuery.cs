using MediatR;
using Nexus.Core.API.Models;

namespace Nexus.Core.API.Orders.Queries
{
    public class GetOrdersQuery : IRequest<IEnumerable<Order>>
    {
    }
}