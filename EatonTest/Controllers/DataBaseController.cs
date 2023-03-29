using EatonTest.Models;
using EatonTest.Repository;
using EatonTest.Settings;
using Microsoft.EntityFrameworkCore;

namespace EatonTest.Controllers;

/// <summary>
/// Extensions for manage database data
/// </summary>
public class DataBaseController : IDataBaseController
{
    private readonly IDevicesSettings _devicesSettings;

    public DataBaseController(IDevicesSettings devicesSettings)
    {
        _devicesSettings = devicesSettings;
    }

    /// <summary>
    /// Get first device measurement
    /// </summary>
    /// <param name="db">Data base name</param>0
    /// <param name="deviceId">Data base table item Id</param>
    /// <returns>List of InputData</returns>
    public async Task<Dictionary<string, string>> GetFirstDeviceMeasurement(DevicesDbContext db, string deviceId)
    {
        var lastMeasurement = await GetDeviceData(db, deviceId);

        if (lastMeasurement == null)
        {
            return new Dictionary<string, string>();
        }

        await RemoveDeviceMeasurementFromDb(db, lastMeasurement.Id);
        return lastMeasurement.Measurements!;
    }

    /// <summary>
    /// Remove Measurement From Device Db
    /// </summary>
    /// <param name="db">Data base name</param>
    /// <param name="deviceId">Data base table item Id</param>
    /// <returns>List of InputData</returns>
    private static async Task RemoveDeviceMeasurementFromDb(DevicesDbContext db, int deviceId)
    {
        db.DeviceMeasurements.Remove((await db.DeviceMeasurements.FindAsync(deviceId))!);
        await db.SaveChangesAsync();
    }

    /// <summary>
    /// Get data from InputDb by type
    /// </summary>
    /// <param name="db">Data base</param>
    /// <param name="deviceId">Type of device</param>
    /// <returns>List of InputData</returns>
    private async Task<DeviceData> GetDeviceData(DevicesDbContext db, string deviceId) => 
        (await db.DeviceMeasurements
            .Where(m => m.DeviceName!
                .Contains(_devicesSettings.GetDeviceTypeData(deviceId)!))
            .Select(d => d).FirstOrDefaultAsync())!;

}