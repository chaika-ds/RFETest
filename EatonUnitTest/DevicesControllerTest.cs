using EatonTest.Controllers;
using EatonTest.Repository;
using EatonUnitTest.Fakes;
using EatonUnitTest.Fakes.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace EatonUnitTest;

/// <summary>
/// Integration tests for device controller
/// </summary>
public class DevicesControllerTest : IClassFixture<FakeFixture>
{
    private readonly IServiceProvider _serviceProvider;
    private DevicesDbContext Context { get; }
    private Dictionary<string, string> MeasurementsTest => new() { ["TestKey"] = "TestValue" };

    public DevicesControllerTest(FakeFixture fakeFixture)
    {
        _serviceProvider = fakeFixture.GetServiceProviderForController();

        var _ = new DevicesDbTest(_serviceProvider, MeasurementsTest);
        Context = _serviceProvider.GetRequiredService<DevicesDbContext>();
    }

    /// <summary>
    /// Test if GetDeviceData send result on InputId and removes this data from repository
    /// </summary>
    [Fact]
    public async void GetDeviceData_InputId_GetResultAndRemoved()
    {
        //Arrange            
        var devicesController = new DevicesController(_serviceProvider);
        var inputIdTest = "0";
            
        //Act
        var result = await devicesController.GetDeviceData(Context, inputIdTest);

        //Assert
        Assert.NotNull(result);
        Assert.DoesNotContain(inputIdTest, Context.DeviceMeasurements.Select(inp => inp.Id).ToString()!);
        Assert.Contains(MeasurementsTest, Context.DeviceMeasurements.Select(inp => inp.Measurements));
    }
}