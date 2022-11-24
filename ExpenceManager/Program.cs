using Microsoft.EntityFrameworkCore;
using ExpenceManager;
using Repositories;
using Entities;
using Repositories.Interfaces;
using Services.Interfaces;
using Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => options.Filters.Add(new ExceptionFilter()));
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RepositoryContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL"))
);
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IRepository<Receipt>, ReceiptRepository>();
builder.Services.AddScoped<IRepository<ReceiptPosition>, ReceiptPositionRepository>();
builder.Services.AddScoped<IRepository<ProductCategory>, ProductCategoryRepository>();
builder.Services.AddScoped<IRepository<UnitOfMeasurement>, UnitOfMeasurementRepository>();

builder.Services.AddScoped<IReceiptService, ReceiptService>();
builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();
builder.Services.AddScoped<IUnitOfMeasurementService, UnitOfMeasurementService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();
app.Run();