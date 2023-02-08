using bgTeam.Extensions;
using RFETest.Controllers;
using RFETest.DataBase;
using RFETest.Models;

namespace RFETest.Extensions
{
    /// <summary>
    /// Extensions for Web application
    /// </summary>
    public static class WebApplicationExtensions
    {
        /// <summary>
        /// Register REST endpoint functions
        /// </summary>
        /// <param name="app">WebApplication</param>
        /// <param name="services">IServiceCollection</param>
        public static void RegisterRest(this WebApplication app, IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var controller = new DirectionController(serviceProvider);

            app.MapGet("/", () => "Comparing application. Chaika D");

            var directions = services.GetRfeSettings().Direction;
            var uri = @"/v1/diff/{id}/";

            directions.DoForEach(dir =>
                {
                    app.MapPost(uri + dir, async (string id, InputData input, InputDb db) =>
                    {
                        return await controller.AddIncomePost(db, id, input, dir, uri);
                    });
                });

            app.MapGet("/v1/diff/{id}", async (string id, InputDb db) =>
            {
                return await controller.CompareIncomeGet(db, id, directions);
            });
        }      
    }
}
