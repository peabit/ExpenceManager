using Entities;
using Repositories.Interfaces;

namespace Repositories;

public interface IRepositoryManager
{
    IRepository<Receipt> Receipt { get; }
    IRepository<ReceiptPosition> ReceiptPosition { get; }
    IRepository<ProductCategory> ProductCategory { get; }
    IRepository<UnitOfMeasurement> UnitOfMeasurement { get; }
}   