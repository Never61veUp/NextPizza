using Microsoft.EntityFrameworkCore;
using NextPizza.Core.Abstractions;
using NextPizza.Persistence;
using NextPizza.Application.Services;
using NextPizza.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<NextPizzaDbContext>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(NextPizzaDbContext)));
    });

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
