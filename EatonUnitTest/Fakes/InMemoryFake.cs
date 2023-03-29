using EatonTest.Repository;
using EatonUnitTest.Fakes.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace EatonUnitTest.Fakes;

/// <summary>
/// Class for fake InMemory
/// </summary>
internal class InMemoryFake
{

    /// <summary>
    /// Register in memory fake db context
    /// </summary>
    /// <param name="services">Service collection</param>
    internal static void RegisterDbContext(IServiceCollection services)
    {
        var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<DevicesDbContext>));

        if (descriptor != null) services.Remove(descriptor);

        services.AddSingleton<IDbContextOptionsTest, DbContextOptionsTest>();

        services
            .AddEntityFrameworkInMemoryDatabase()
            .AddDbContext<DevicesDbContext>((sp, options) =>
            {
                var databaseId = sp.GetRequiredService<IDbContextOptionsTest>().DatabaseId;

                options
                    .EnableSensitiveDataLogging()
                    .UseInMemoryDatabase(databaseName: $"FakeDb_{databaseId}")
                    .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                    .UseInternalServiceProvider(sp);
            });
    }
}