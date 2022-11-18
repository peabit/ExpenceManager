using Entities;

namespace Repositories;

public class ReceiptRepository : RepositoryBase<Receipt>
{
    public ReceiptRepository(RepositoryContext context) : base(context) { }
}