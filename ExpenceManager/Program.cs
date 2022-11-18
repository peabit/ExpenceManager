using Microsoft.EntityFrameworkCore;
using ExpenceManager;
using Repositories;
using Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => options.Filters.Add(new ExceptionFilter()));
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RepositoryContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL"))
);
builder.Services.AddScoped<RepositoryBase<ReceiptPosition>, ReceiptPositionRepository>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();
app.Run();