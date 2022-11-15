using Microsoft.EntityFrameworkCore;
using Entities;

namespace Repositories;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options) : base(options)
    {
        //Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(
            message => System.Diagnostics.Debug.WriteLine(message),
            new[ ] { DbLoggerCategory.Database.Command.Name }
        );
    }
    public DbSet<Receipt> Receipts { get; set; }
    public DbSet<ReceiptPosition> ReceiptPositions { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<UnitOfMeasurement> UnitOfMeasurement { get; set; }
}