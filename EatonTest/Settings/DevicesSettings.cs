namespace EatonTest.Settings;

/// <summary>
/// Configuration section of devices
/// </summary>
public class DevicesSettings : IDevicesSettings
{
    public DevicesSettings(IConfiguration configuration)
    {
        Devices = configuration.GetSection("Devices").Value.Split(',').ToList();
    }

    /// <summary>
    /// Endpoint devices settings
    /// </summary>
    private List<string> Devices { get; }

    /// <summary>
    /// Get device type by device name
    /// </summary>
    /// <param name="inputDevice"></param>
    /// <returns></returns>
    public string GetDeviceTypeData(string inputDevice) =>
        Devices[int.Parse(inputDevice)].Trim();
}