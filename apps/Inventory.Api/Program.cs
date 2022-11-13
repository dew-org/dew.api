using Dew.Inventory.Api.Endpoints;
using Dew.Inventory.Api.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapInventoryApi();

app.UseCors(Infrastructure.CorsPolicy);

app.Run();

#pragma warning disable CA1050 // Declare types in namespaces
public partial class Program
{
    // For testing purposes
}
#pragma warning restore CA1050 // Declare types in namespaces
