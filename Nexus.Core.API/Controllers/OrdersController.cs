using Microsoft.AspNetCore.Mvc;
using Nexus.Core.API.Models;

namespace Nexus.Core.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        // Static list to simulate a database for testing purposes
        private static List<Order> _orders = new List<Order>
        {
            new Order { Id = 1, OrderName = "Laptop", Quantity = 1 },
            new Order { Id = 2, OrderName = "Mouse", Quantity = 5 }
        };

        // 1. GET ALL ORDERS 
        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetAllOrders([FromQuery] string? status)
        {
            return Ok(_orders); // Returns HTTP 200 OK with the list of orders
        }

        // 2. GET SINGLE ORDER BY ID
        [HttpGet("{id}")]
        public ActionResult<Order> GetOrderById([FromRoute] int id)
        {
            var order = _orders.FirstOrDefault(o => o.Id == id);

            // Returns HTTP 404
            if (order == null) return NotFound();

            return Ok(order); // Returns HTTP 200 OK 
        }

        // 3. POST - CREATE NEW ORDER
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] Order newOrder, CancellationToken ct)
        {

            // Assigning a new ID based on the current maximum ID in the list
            newOrder.Id = _orders.Max(o => o.Id) + 1;
            _orders.Add(newOrder);

            // Returns HTTP 201 Created
            return CreatedAtAction(nameof(GetOrderById), new { id = newOrder.Id }, newOrder);
        }
    }
}