using MediatR;
using Nexus.Core.API.Models;
using Nexus.Core.API.Orders.Commands;
using Nexus.Core.API.Orders.Validators;
using Nexus.Core.API.Services;

namespace Nexus.Core.API.Orders.Handlers
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Order>
    {
        private readonly OrderService _orderService;

        public CreateOrderHandler(OrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            // Validate before handling
            var validator = new CreateOrderValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new Exception(errors);
            }

            // Map command to Order model
            var order = new Order
            {
                OrderName = request.OrderName,
                CustomerName = request.CustomerName,
                TotalAmount = request.TotalAmount
            };

            return await _orderService.CreateOrderAsync(order);
        }
    }
}