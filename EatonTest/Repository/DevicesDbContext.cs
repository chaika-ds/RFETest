using EatonTest.Models;
using Microsoft.EntityFrameworkCore;

namespace EatonTest.Repository;

/// <summary>
/// Db context for device indicators measurements
/// </summary>
public class DevicesDbContext : DbContext
{
    public DevicesDbContext(DbContextOptions<DevicesDbContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// OnConfiguring
    /// </summary>
    /// <param name="optionsBuilder">DbContextOptionsBuilder</param>
    protected override void OnConfiguring
        (DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "DevicesIndicators");
    }

    /// <summary>
    /// DbSet of DeviceData table
    /// </summary>
    public DbSet<DeviceData> DeviceMeasurements { get; set; } = null!;

    /// <summary>
    /// ModelCreating override adjustments
    /// </summary>
    /// <param name="modelBuilder">ModelBuilder</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DeviceData>()
            .Property(devices => devices.Measurements)
            .HasConversion<DictionaryConverter<string, string>>();
    }
}