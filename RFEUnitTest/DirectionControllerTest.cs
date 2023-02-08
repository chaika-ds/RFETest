using Microsoft.Extensions.DependencyInjection;
using RFETest.Controllers;
using RFETest.DataBase;
using RFETest.Models;
using RFEUnitTest.Fakes;
using RFEUnitTest.Fakes.Repository;

namespace RFEUnitTest
{
    public class DirectionControllerTest : IClassFixture<FakeFixture>
    {
        private readonly IServiceProvider _serviceProvider;
        private InputDb _context { get; }

        public DirectionControllerTest(FakeFixture fakeFixture)
        {
            _serviceProvider = fakeFixture.GetServiceProviderForController();
             new InputDbTest().Initialise(_serviceProvider);
            _context = _serviceProvider.GetRequiredService<InputDb>();
        }

        /// <summary>
        /// Test if InputData was inserted to repository
        /// </summary>
        [Fact]
        public async void AddIncomePost_InsertInputData_Inserted()
        {
            //Arrange            
            var directionController = new DirectionController(_serviceProvider);
            var inputIdTest = "InputIdTest";
            var directionTest = "left";
            var testInput = "TestInput";
            var uriTest = "UriTest";
            var inputData = new InputData() {
                InputId = inputIdTest, Input = testInput, InputType = directionTest
            };
            //Act
            var result = await directionController.AddIncomePost(_context, inputIdTest, inputData, directionTest, uriTest);

            //Assert
            Assert.NotNull(result);
            Assert.Contains(inputIdTest, _context.Inputs.Select(inp => inp.InputId));
            Assert.Contains(directionTest, _context.Inputs.Select(inp => inp.InputType));
            Assert.Contains(testInput, _context.Inputs.Select(inp => inp.Input));
        }
    }
}
