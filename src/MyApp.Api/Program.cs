using MyApp.Application.Interfaces;
using MyApp.Application.Services;
using MyApp.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Dependency Injection
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

// Map endpoints
app.MapControllers();

app.Run();
