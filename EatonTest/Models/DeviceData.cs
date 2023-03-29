using Microsoft.EntityFrameworkCore;

namespace EatonTest.Models;

/// <summary>
/// Class for Device data
/// </summary>
[Index(nameof(Id))]
public class DeviceData
{
    /// <summary>
    /// Id for device indicator
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Device Name
    /// </summary>
    public string? DeviceName { get; set; }

    /// <summary>
    /// Current device measurements
    /// </summary>
    public Dictionary<string, string>? Measurements { get; set; }
}