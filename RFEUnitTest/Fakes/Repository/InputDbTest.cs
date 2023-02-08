using Microsoft.Extensions.DependencyInjection;
using RFETest.DataBase;
using RFETest.Models;

namespace RFEUnitTest.Fakes.Repository
{
    internal class InputDbTest
    {
        private InputDb Context { get; set; }

        public InputDbTest()
        {
        }

        /// <summary>
        ///  Initialise db Context and fill data
        /// </summary>
        public void Initialise(IServiceProvider serviceProvider)
        {
            Context = serviceProvider.GetRequiredService<InputDb>();

            GenerateFakeSeoDbContext();
        }

        /// <summary>
        ///  Generate data for InputData DbSets
        /// </summary>
        private void GenerateFakeSeoDbContext()
        {
            Context.Database.EnsureDeleted();
            Context.Database.EnsureCreated();

            for (var i = 1; i <= 10; i++)
            {
                AddInputData(i);
            }

            Context.SaveChanges();
        }

        /// <summary>
        ///  Generate data for InputData DbSets
        /// </summary>
        /// <param name="i">Integer property for differentiate properties</param>
        public void AddInputData(int i)
        {
            if (!Context.Inputs.Any())
            {
                Context.Inputs.Add(new InputData()
                {
                    Id = i,
                    InputId = "Id " + i,
                    Input = "InputValue" + i,
                    InputType = "InputType" + i
                });
            }
        }
    }
}
