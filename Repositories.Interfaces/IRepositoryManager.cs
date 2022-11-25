using Entities;

namespace Repositories.Interfaces;

public interface IRepositoryManager
{
    IRepository<Receipt> Receipt { get; }
    IRepository<ReceiptPosition> ReceiptPosition { get; }
    IRepository<ProductCategory> ProductCategory { get; }
    IRepository<UnitOfMeasurement> UnitOfMeasurement { get; }
}   