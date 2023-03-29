using EatonTest.Controllers;
using EatonTest.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace EatonUnitTest.Fakes;

/// <summary>
/// Fake fixtures
/// </summary>
public class FakeFixture
{
    /// <summary>
    /// Get service provider for workers jobs
    /// </summary>
    /// <returns>Service provider</returns>
    public IServiceProvider GetServiceProviderForController()
    {
        var services = ServiceCollectionFake.CreateServiceCollectionFake();

        InMemoryFake.RegisterDbContext(services);
        services.AddScoped<IDevicesSettings, DevicesSettings>();
        services.AddScoped<IDataBaseController, DataBaseController>();

        var serviceProvider = services.BuildServiceProvider();
        return serviceProvider;
    }
}