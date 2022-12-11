using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using ExpenceManager.Filters;
using Repositories;
using Repositories.Interfaces;
using Services.Interfaces;
using Services;
using FluentValidation;
using DataTransferObjects;
using ExpenceManager.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ExceptionFilter());
    options.Filters.Add(new ResponseStatusCodeFilter());
});

// TODO: Move to extension method
builder.Services.AddFluentValidationAutoValidation(config =>
{
    config.DisableDataAnnotationsValidation = true;
});

builder.Services.AddScoped<IValidator<NewReceiptPositionDto>, ReceiptPositionValidator>();
builder.Services.AddScoped<IValidator<NewReceiptDto>, ReceiptValidator>();
builder.Services.AddScoped<IValidator<NewProductCategoryDto>, ProductCategoryValidator>();
builder.Services.AddScoped<IValidator<NewUnitOfMeasurementDto>, UnitOfMeasurementValidator>();

builder.Services.AddSwaggerGen();

// TODO: Move to extension method
builder.Services.AddDbContext<RepositoryContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL"))
);
builder.Services.AddAutoMapper(typeof(Program));

// TODO: Move to extension method
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();

// TODO: Move to extension method
builder.Services.AddScoped<IReceiptService, ReceiptService>();

// TODO: Move to extension method
builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();

// TODO: Move to extension method
builder.Services.AddScoped<IUnitOfMeasurementService, UnitOfMeasurementService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();
app.Run();