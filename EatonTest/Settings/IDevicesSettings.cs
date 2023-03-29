namespace EatonTest.Settings;

/// <summary>
/// Settings for endpoints configuration
/// </summary>
public interface IDevicesSettings
{
    /// <summary>
    /// Devices settings
    /// </summary>
    string? GetDeviceTypeData(string inputDevice);

}