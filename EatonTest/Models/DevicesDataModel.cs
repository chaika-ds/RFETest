using Newtonsoft.Json;

namespace EatonTest.Models;

/// <summary>
/// Model for filling data to DB from JSON file
/// </summary>
public class DevicesDataModel
{
    /// <summary>
    /// Fillers of devices model
    /// </summary>
    [JsonProperty("Fillers")]
    public DeviceData[] Fillers { get; set; } = null!;
}