using EatonTest.Models;
using EatonTest.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace EatonUnitTest.Fakes.Repository;

/// <summary>
/// Class for filling fake repository with test data
/// </summary>
internal class DevicesDbTest
{
    private DevicesDbContext Context { get; }
    private readonly Dictionary<string, string> _measurementsTest;

    public DevicesDbTest(IServiceProvider serviceProvider, Dictionary<string, string> measurements)
    {
        Context = serviceProvider.GetRequiredService<DevicesDbContext>();
        _measurementsTest = measurements;
        GenerateFakeSeoDbContext();
    }

    /// <summary>
    ///  Insert DeviceData to fake DbSet
    /// </summary>
    private void GenerateFakeSeoDbContext()
    {
        Context.Database.EnsureDeleted();
        Context.Database.EnsureCreated();

        for (var i = 1; i <= 2; i++)
        {
            AddInputData(i);
        }

        Context.SaveChanges();
    }

    /// <summary>
    ///  Generate data for DeviceData DbSets
    /// </summary>
    /// <param name="i">Integer property for differentiate properties</param>
    public void AddInputData(int i)
    {
        if (!Context.DeviceMeasurements.Any())
        {
            Context.DeviceMeasurements.Add(new DeviceData()
            {
                Id = i,
                DeviceName = $"DeviceTest{i}",
                Measurements = _measurementsTest
            });
        }
    }
}