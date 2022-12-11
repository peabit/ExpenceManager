using DataTransferObjects;
using FluentValidation;

namespace ExpenceManager.Validators;

public class ProductCategoryValidator : AbstractValidator<NewProductCategoryDto>
{
	public ProductCategoryValidator()
	{
		RuleFor(c => c.Name).NotEmpty();
	}
}