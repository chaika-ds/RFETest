using bgTeam.Extensions;
using EatonTest.Models;
using EatonTest.Resources;

namespace EatonTest.Repository;

/// <summary>
/// Class for filling repository with resource data
/// </summary>
public class GenericDeviceRepository
{
    public GenericDeviceRepository(DevicesDbContext context)
    {
        InitialiseData(DeviceResourcesGenerator.GetResourcedDataModel(), context);
    }

    /// <summary>
    ///  Initialise db Context and fill data
    /// </summary>
    private void InitialiseData(DevicesDataModel? devicesData, DevicesDbContext context)
    {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        devicesData!.Fillers.DoForEach(d =>
        {
            context.DeviceMeasurements.AddRange(d);
        });

        context.SaveChanges();
    }
}