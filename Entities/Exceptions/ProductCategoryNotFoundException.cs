namespace Entities.Exceptions;

public sealed class ProductCategoryNotFoundException : NotFoundException
{
    public ProductCategoryNotFoundException(int id)
        : base($"Product category with id: {id} doesn`t exist in the database.") { }
}