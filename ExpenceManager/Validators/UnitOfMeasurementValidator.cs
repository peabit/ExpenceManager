using DataTransferObjects;
using FluentValidation;

namespace ExpenceManager.Validators;

public class UnitOfMeasurementValidator : AbstractValidator<NewUnitOfMeasurementDto>
{
	public UnitOfMeasurementValidator()
	{
		RuleFor(u => u.Name).NotEmpty();
        RuleFor(u => u.Description).NotEmpty();
    }
}