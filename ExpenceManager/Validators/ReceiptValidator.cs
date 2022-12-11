using DataTransferObjects;
using FluentValidation;

namespace ExpenceManager.Validators;

public class ReceiptValidator : AbstractValidator<NewReceiptDto>
{
	public ReceiptValidator()
	{
        RuleFor(r => r.ShopName).NotEmpty();
        RuleFor(r => r.DateTime).NotEmpty();
        RuleFor(r => r.Positions).NotEmpty();
        RuleForEach(r => r.Positions).SetValidator(new ReceiptPositionValidator());
    }
}
