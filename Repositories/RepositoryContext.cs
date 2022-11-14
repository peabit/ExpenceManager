using Microsoft.EntityFrameworkCore;
using Entities;

namespace Repositories;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options) : base(options)
    {
        //Database.EnsureCreated();
    }

    public DbSet<Receipt>? Receipts { get; set; }
    public DbSet<ReceiptPosition>? ReceiptPositions { get; set; }
}