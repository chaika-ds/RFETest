using EatonTest.Models;
using Newtonsoft.Json;

namespace EatonTest.Resources;

/// <summary>
/// Class for generation device measurements data from resource
/// </summary>
internal static class DeviceResourcesGenerator
{
    /// <summary>
    /// Serialize devices Data to model
    /// </summary>
    internal static DevicesDataModel? GetResourcedDataModel() =>
        JsonConvert.DeserializeObject<DevicesDataModel>(System.Text.Encoding.Default.GetString(GetResourceData()!));


    /// <summary>
    /// Get device data from resource
    /// </summary>
    private static byte[]? GetResourceData() => DeviceResources.DevicesMasurementsData;
}