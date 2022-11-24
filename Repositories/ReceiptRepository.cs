using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories;

public sealed class ReceiptRepository : RepositoryBase<Receipt>
{
    public ReceiptRepository(RepositoryContext context) : base(context) { }
}