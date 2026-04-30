using System.ComponentModel.DataAnnotations;

namespace Nexus.Core.API.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "OrderName is mandatory")] // Validation: Required
        public string OrderName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")] // Validation: > 0
        public int Quantity { get; set; }
    }
}