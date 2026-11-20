using Lab08_LeonelPortillo.Models;
using Lab08_LeonelPortillo.Repository;
using Lab08_LeonelPortillo.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Controladores y configuracion JSON para evitar ciclos en las relaciones
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Conexion a PostgreSQL y registro temporal de consultas SQL
var connectionString = builder.Configuration.GetConnectionString("PostgresConnection");

if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException(
        "No se encontro la cadena de conexion 'PostgresConnection' en appsettings.json.");
}

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(connectionString);
    options.EnableDetailedErrors();
    options.LogTo(Console.WriteLine, LogLevel.Information);
});

// Repositorios
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Servicios
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();

var app = builder.Build();

// Swagger en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();