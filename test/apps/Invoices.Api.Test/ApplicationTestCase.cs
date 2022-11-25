using Dew.Shared.Domain.Persistence;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Invoices.Api.Test;

public class ApplicationTestCase : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly MongoDbTestcontainer _dbContainer = new TestcontainersBuilder<MongoDbTestcontainer>()
        .WithDatabase(new MongoDbTestcontainerConfiguration
        {
            Database = "dew",
            Username = "dew",
            Password = "dew"
        })
        .Build();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            services.RemoveAll(typeof(MongoDbSettings));

            services.Configure<MongoDbSettings>(options =>
            {
                options.ConnectionString = _dbContainer.ConnectionString;
                options.DatabaseName = _dbContainer.Database;
                options.CollectionName = "inventory";
            });
        });
    }

    public async Task InitializeAsync()
    {
        await _dbContainer.StartAsync();
    }

    public new async Task DisposeAsync()
    {
        await _dbContainer.StopAsync();
    }
}
