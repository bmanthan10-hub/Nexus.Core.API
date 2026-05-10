using FluentValidation;
using Nexus.Core.API.Orders.Commands;

namespace Nexus.Core.API.Orders.Validators
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderValidator()
        {
            RuleFor(x => x.OrderName)
                .NotEmpty().WithMessage("Order name cannot be empty.")
                .MaximumLength(100).WithMessage("Order name cannot exceed 100 characters.");

            RuleFor(x => x.CustomerName)
                .NotEmpty().WithMessage("Customer name cannot be empty.");

            RuleFor(x => x.TotalAmount)
                .GreaterThan(0).WithMessage("Total amount must be greater than 0.");
        }
    }
}