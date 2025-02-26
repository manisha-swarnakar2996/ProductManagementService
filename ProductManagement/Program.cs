using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductManagement.Services;
using ProductManagementApi.Data;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "ProductManagement",
        Description = "Product Management API",
    });
      
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))); // Ensure Npgsql is referenced

// Register the ProductService as a dependency
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product Management API v1");
    }); // Ensure Swagger UI is configured properly
}
app.UseRouting(); // Add this line before app.UseAuthorization()
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();