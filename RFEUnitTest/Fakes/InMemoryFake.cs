using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using RFETest.DataBase;
using RFEUnitTest.Fakes.Repository;

namespace RFEUnitTest.Fakes
{
    internal class InMemoryFake
    {

        /// <summary>
        ///     Register in memory db context
        /// </summary>
        /// <param name="services">Service collection</param>
        internal static void RegisterDbContext(IServiceCollection services)
        {
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<InputDb>));

            if (descriptor != null) services.Remove(descriptor);

            services.AddSingleton<IDbContextOptionsTest, DbContextOptionsTest>();

            services
                .AddEntityFrameworkInMemoryDatabase()
                .AddDbContext<InputDb>((sp, options) =>
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
}
