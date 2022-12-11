using DataTransferObjects;
using FluentValidation;

namespace ExpenceManager.Validators;

public class ReceiptPositionValidator : AbstractValidator<NewReceiptPositionDto>
{
	public ReceiptPositionValidator()
	{
		RuleFor(p => p.ProductName).NotEmpty();
        RuleFor(p => p.Quantity).GreaterThan(0);
        RuleFor(p => p.Price).GreaterThanOrEqualTo(0);
        RuleFor(p => p.UnitOfMeasurementId).NotEmpty();
        RuleFor(p => p.ProductCategoryId).NotEmpty();       
    }
}