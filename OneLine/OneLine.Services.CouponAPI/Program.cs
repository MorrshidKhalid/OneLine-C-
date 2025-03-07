using Microsoft.EntityFrameworkCore;
using OneLine.Services.CouponAPI.Data;
using OneLine.Services.CouponAPI.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICouponService, CouponServiceImpl>();

var connectionString = builder.Configuration.GetConnectionString("DefualtConnection");
// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(connectionString);
});

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
