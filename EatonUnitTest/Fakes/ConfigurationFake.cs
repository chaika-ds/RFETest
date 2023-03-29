using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Moq;

namespace EatonUnitTest.Fakes;

/// <summary>
/// Fake Configuration class for DI unit test
/// </summary>
public class ConfigurationFake : IConfiguration
{
    /// <summary>
    /// GetChildren fake
    /// </summary>
    /// <returns>new IConfigurationSection[]{}</returns>
    public IEnumerable<IConfigurationSection> GetChildren()
    {
        return new IConfigurationSection[] {};
    }

    /// <summary>
    /// GetReloadToken fake
    /// </summary>
    /// <returns>new CancellationChangeToken(new CancellationToken())</returns>
    public IChangeToken GetReloadToken()
    {
        return new CancellationChangeToken(new CancellationToken());
    }

    /// <summary>
    /// GetSection fake
    /// </summary>
    /// <param name="key">key</param>
    /// <returns>Mocked IConfigurationSection with "DeviceTest1, DeviceTest2"</returns>
    public IConfigurationSection GetSection(string key)
    {
         var mockSection = new Mock<IConfigurationSection>();
         mockSection.Setup(x => x.Value).Returns("DeviceTest1, DeviceTest2");

        return mockSection.Object;
    }

    /// <summary>
    /// key
    /// </summary>
    /// <param name="key">key</param>
    /// <returns>string key</returns>
    public string? this[string key]
    {
        get => "testKey";
        set { }
    }
}