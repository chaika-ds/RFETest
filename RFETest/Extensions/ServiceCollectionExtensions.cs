using bgTeam.Extensions;
using RFETest.DataBase;
using Microsoft.EntityFrameworkCore;
using RFETest.Settings;

namespace RFETest.Extensions;

/// <summary>
/// Extensions for ServiceCollection
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Register settings for Rfe project
    /// </summary>
    /// <param name="services">IServiceCollection</param>
    public static void RegisterRfeSettings(this IServiceCollection services)
    {
        services.AddSettings<IRfeSettings, RfeSettings>();
    }

    /// <summary>
    /// Register services for Rfe project
    /// </summary>
    /// <param name="services">IServiceCollection</param>
    public static void RegisterRfeServices(this IServiceCollection services)
    {
        services.AddSingleton<IDataBaseChecking, DataBaseChecking>();
    }

    /// <summary>
    ///     Get Rfe settings
    /// </summary>
    /// <param name="services">IServiceCollection</param>
    public static IRfeSettings GetRfeSettings(this IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();
        return serviceProvider.GetRequiredService<IRfeSettings>();

    }
    /// <summary>
    ///     Register In Memory database
    /// </summary>
    /// <param name="services">IServiceCollection</param>
    public static void RegisterInMemory(this IServiceCollection services)
    {
        services.AddDbContext<InputDb>(opt => opt.UseInMemoryDatabase("InputList"));
        services.AddDatabaseDeveloperPageExceptionFilter();
    }
}
