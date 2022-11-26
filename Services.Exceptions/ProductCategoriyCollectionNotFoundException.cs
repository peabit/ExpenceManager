namespace Services.Exceptions;

public sealed class ProductCategoriyCollectionNotFoundException : NotFoundException
{
	public ProductCategoriyCollectionNotFoundException() 
		: base("Product categories not found.") { }
}