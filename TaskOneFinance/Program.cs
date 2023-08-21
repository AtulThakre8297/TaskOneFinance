using Microsoft.EntityFrameworkCore;
using ProductAppAPI.Repository;
using TaskOneFinance.Configuration;
using TaskOneFinance.Context;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
String con = builder.Configuration.GetConnectionString("LocalConnectionString");
builder.Services.AddDbContext<ProductDbContext>(p => p.UseSqlServer(con));
builder.Services.AddAutoMapper(typeof(Mapping));
builder.Services.AddScoped<IProductRepository,ProductRepository>();



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
