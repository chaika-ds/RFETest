using AuditService.Tests.Fakes.ServiceData;
using Microsoft.Extensions.DependencyInjection;
using RFETest.DataBase;
using RFEUnitTest.Fakes.Repository;

namespace RFEUnitTest.Fakes
{
    public class FakeFixture
    {
        /// <summary>
        ///     Get service provider for workers jobs
        /// </summary>
        /// <returns>Service provider</returns>
        public IServiceProvider GetServiceProviderForController()
        {
            var services = ServiceCollectionFake.CreateServiceCollectionFake();

            InMemoryFake.RegisterDbContext(services);
            services.AddScoped<IDataBaseChecking, DataBaseCheckingFake>();

            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
