using Entities;
using Repositories.Interfaces;

namespace Repositories;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _context;

    private readonly Lazy<IRepository<Receipt>> _receipt;
    private readonly Lazy<IRepository<ReceiptPosition>> _receiptPosition;
    private readonly Lazy<IRepository<ProductCategory>> _productCategory;
    private readonly Lazy<IRepository<UnitOfMeasurement>> _unitOfMeasurement;

    public RepositoryManager(RepositoryContext context)
    {
        _context = context;

        _receipt = new Lazy<IRepository<Receipt>>(() => new ReceiptRepository(_context));
        _receiptPosition = new Lazy<IRepository<ReceiptPosition>>(() => new ReceiptPositionRepository(_context));
        _productCategory = new Lazy<IRepository<ProductCategory>>(() => new ProductCategoryRepository(_context));
        _unitOfMeasurement = new Lazy<IRepository<UnitOfMeasurement>>(() => new UnitOfMeasurementRepository(_context));
    }

    public IRepository<Receipt> Receipt 
        => _receipt.Value;

    public IRepository<ReceiptPosition> ReceiptPosition
        => _receiptPosition.Value;

    public IRepository<ProductCategory> ProductCategory
        => _productCategory.Value;

    public IRepository<UnitOfMeasurement> UnitOfMeasurement
        => _unitOfMeasurement.Value;
}