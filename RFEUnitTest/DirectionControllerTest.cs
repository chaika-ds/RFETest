using Microsoft.Extensions.DependencyInjection;
using RFETest.Controllers;
using RFETest.DataBase;
using RFETest.Models;
using RFEUnitTest.Fakes;

namespace RFEUnitTest
{
    public class DirectionControllerTest : IClassFixture<FakeFixture>
    {
        private readonly IServiceProvider _serviceProvider;
        private InputDb _context { get; }

        public DirectionControllerTest(FakeFixture fakeFixture)
        {
            _serviceProvider = fakeFixture.GetServiceProviderForController();
            _context = _serviceProvider.GetRequiredService<InputDb>(); 

        }

        [Fact]
        public async void AddIncomePost_()
        {
            //Arrange            
            var directionController = new DirectionController(_serviceProvider);
            var inputIdTest = "InputIdTest";
            var directionTest = "left";
            var uriTest = "UriTest";
            var inputData = new InputData() {
                Id = 1, InputId = inputIdTest, Input = "TestInput", InputType = directionTest
            };
            //Act
            var result = await directionController.AddIncomePost(_context, inputIdTest, inputData, directionTest, uriTest);

            //Assert
            Assert.True(result.ExecuteAsync().Status)
        }
    }
}
