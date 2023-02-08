using AuditService.Tests.Fakes.ServiceData;
using RFETest.Extensions;

namespace RFEUnitTest
{
    public class IntegrationTest
    {
        [Fact]
        public void RfeIntegrationTest()
        {
            var services = ServiceCollectionFake.CreateServiceCollectionFake();
            var directions = services.GetRfeSettings().Direction;

            //directions.DoForEach(dir =>
            //{
            //    app.MapPost(@"/v1/diff/{id}/" + dir, async (string id, InputData input, InputDb db) =>
            //    {
            //        return await db.AddIncomePost(id, input, dir);
            //    });
            //});
        }
    }
}