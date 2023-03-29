using EatonTest.Controllers;
using EatonTest.Repository;

namespace EatonTest.Extensions;

/// <summary>
/// Extensions for Web application
/// </summary>
public static class WebApplicationExtensions
{
    /// <summary>
    /// Register REST endpoint functions
    /// </summary>
    /// <param name="app">WebApplication</param>
    /// <param name="services">IServiceCollection</param>
    public static void RegisterRest(this WebApplication app, IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();
        var controller = new DevicesController(serviceProvider);

        serviceProvider.GetRequiredService<GenericDeviceRepository>();

        app.MapGet("/", () => "Eaton devices modeling application. Chaika D");

        const string uri = @"/v1/device/{id}";

        app.MapGet(uri, async (string id, DevicesDbContext db)
            => await controller.GetDeviceData(db, id));
    }
}