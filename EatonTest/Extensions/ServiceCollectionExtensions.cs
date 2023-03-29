using bgTeam.Extensions;
using EatonTest.Controllers;
using EatonTest.Repository;
using EatonTest.Settings;
using Microsoft.EntityFrameworkCore;

namespace EatonTest.Extensions;

/// <summary>
/// Extensions for ServiceCollection
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Register settings for Eaton project
    /// </summary>
    /// <param name="services">IServiceCollection</param>
    public static void RegisterDeviceSettings(this IServiceCollection services)
    {
        services.AddSettings<IDevicesSettings, DevicesSettings>();
    }


    /// <summary>
    /// Register services for project
    /// </summary>
    /// <param name="services">IServiceCollection</param>
    public static void RegisterDataBaseServices(this IServiceCollection services)
    {
        services.AddSingleton<IDataBaseController, DataBaseController>();
    }

    /// <summary>
    /// Register In Memory database
    /// </summary>
    /// <param name="services">IServiceCollection</param>
    public static void RegisterInMemory(this IServiceCollection services)
    {        
        services.AddDatabaseDeveloperPageExceptionFilter();
        services.AddDbContext<DevicesDbContext>(opt => opt.UseInMemoryDatabase("DevicesIndicators"));
    }

    /// <summary>
    /// Register resources
    /// </summary>
    /// <param name="services">IServiceCollection</param>
    public static void RegisterResources(this IServiceCollection services)
    {
        services.AddTransient<GenericDeviceRepository>();
    }
}
