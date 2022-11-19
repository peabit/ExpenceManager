using Entities;

namespace Repositories.Interfaces;

public interface IReceiptRepository : IRepository<Receipt>
{
    Task CreatePositionAsync(ReceiptPosition position);
    Task<IReadOnlyCollection<ReceiptPosition>> GetPositionsAsync(int receipId);
    Task UpdatePositionAsync(ReceiptPosition position);
    Task DeletePositionAsync(int receiptId, int positionId);
    bool ContainsPosition(int receiptId, int positionId);
}