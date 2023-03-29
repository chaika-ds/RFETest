using EatonTest.Repository;

namespace EatonTest.Controllers;

/// <summary>
/// Extensions for REST endpoint functions
/// </summary>
public class DevicesController
{
    private readonly IDataBaseController _dbController;

    public DevicesController(IServiceProvider serviceProvider)
    {
        _dbController = new Lazy<IDataBaseController>(serviceProvider.GetRequiredService<IDataBaseController>()).Value;
    }


    /// <summary>
    /// Get data for request to device
    /// </summary>
    /// <param name="db">Data base</param>
    /// <param name="id">Id for select data</param>
    /// <returns>Device measurements</returns>
    public async Task<IResult> GetDeviceData(DevicesDbContext db, string id)
    {
        var deviceMeasurements = await _dbController.GetFirstDeviceMeasurement(db, id);
        return deviceMeasurements.Count == 0
            ? Results.NotFound()
            : Results.Json(deviceMeasurements);
    }
}