using EatonTest.Repository;

namespace EatonTest.Controllers;

/// <summary>
/// Controller for data base
/// </summary>
public interface IDataBaseController
{
    /// <summary>
    /// Get first device measurement
    /// </summary>
    /// <param name="db">Data base name</param>0
    /// <param name="deviceId">Data base table item Id</param>
    /// <returns>List of InputData</returns>
    Task<Dictionary<string, string>> GetFirstDeviceMeasurement(DevicesDbContext db, string deviceId);
}