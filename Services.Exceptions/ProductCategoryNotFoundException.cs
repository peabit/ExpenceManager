namespace Services.Exceptions;

public sealed class ProductCategoryNotFoundException : NotFoundException
{
    public ProductCategoryNotFoundException(int id)
        : base($"Product category with id {id} not found.") { }
}