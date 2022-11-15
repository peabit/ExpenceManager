using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories;

public class ReceiptRepository : RepositoryBase<Receipt>
{
    protected override IQueryable<Receipt> Entities 
        => base.Entities
            .Include(r => r.Positions).ThenInclude(p => p.ProductCategory)
            .Include(r => r.Positions).ThenInclude(p => p.UnitOfMeasurement);

    public ReceiptRepository(RepositoryContext context) : base(context) { }
}