using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories;

public sealed class ReceiptPositionRepository : RepositoryBase<ReceiptPosition>
{
    public ReceiptPositionRepository(RepositoryContext context) : base(context) { }
    
    protected override IQueryable<ReceiptPosition> Entities 
        => base.Entities
            .Include(p => p.ProductCategory)
            .Include(p => p.UnitOfMeasurement);

    public override async Task CreateAsync(ReceiptPosition position)
    {
        await base.CreateAsync(position);

        var updatedPosition = await GetFirstOrDefaulAsync( p => p.Id == position.Id);
        position.ProductCategory = updatedPosition!.ProductCategory;
        position.UnitOfMeasurement = updatedPosition!.UnitOfMeasurement;
    }
}