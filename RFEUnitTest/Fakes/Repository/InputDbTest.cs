using Microsoft.Extensions.DependencyInjection;
using RFETest.DataBase;


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
        ///  Generate data for SeoDbContext DbSets
        /// </summary>
        private void GenerateFakeSeoDbContext()
        {
            Context.Database.EnsureDeleted();
            Context.Database.EnsureCreated();

            for (var i = 1; i <= 10; i++)
            {

            }

            Context.SaveChanges();
        }
    }
}
