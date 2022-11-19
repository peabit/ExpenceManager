using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories;

public sealed class ReceiptRepository : RepositoryBase<Receipt>, IReceiptRepository
{
    private IQueryable<ReceiptPosition> Positions
    => _context.ReceiptPositions
        .Include(p => p.ProductCategory)
        .Include(p => p.UnitOfMeasurement)
        .AsNoTracking();

    public ReceiptRepository(RepositoryContext context) : base(context) { }

    public async Task CreatePositionAsync(ReceiptPosition position)
    {
        _context.ReceiptPositions.Add(position);
        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyCollection<ReceiptPosition>> GetPositionsAsync(int receipId)
        => await Positions.Where(p => p.ReceiptId == receipId).ToListAsync();

    public async Task UpdatePositionAsync(ReceiptPosition position)
    {
        _context.ReceiptPositions.Update(position);
        await _context.SaveChangesAsync();
    }

    public async Task DeletePositionAsync(int receiptId, int positionId)
    {
        _context.ReceiptPositions.Remove(new ReceiptPosition
        {
            ReceiptId = receiptId,
            Id = positionId
        });

        await _context.SaveChangesAsync();
    }

    public bool ContainsPosition(int receiptId, int positionId)
        => _context.ReceiptPositions.Any(p => p == new ReceiptPosition
        {
            ReceiptId = receiptId,
            Id = positionId
        });
}