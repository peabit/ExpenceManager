using Microsoft.EntityFrameworkCore;
using ExpenceManager.Filters;
using ExpenceManager;
using Repositories;
using Repositories.Interfaces;
using Services.Interfaces;
using Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ExceptionFilter());
    options.Filters.Add(new ResponseStatusCodeFilter());
});

builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RepositoryContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL"))
);
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IReceiptService, ReceiptService>();
builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();
builder.Services.AddScoped<IUnitOfMeasurementService, UnitOfMeasurementService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();
app.Run();