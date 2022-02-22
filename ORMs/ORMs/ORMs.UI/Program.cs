using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ORMs.BLL.DI;
using ORMs.DAL.EF;

namespace ORMs.UI
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            

            var services = new ServiceCollection();
            ConfigureServices(services);           

            Application app = services
                              .BuildServiceProvider()
                              .GetRequiredService<Application>();

            //
            var context = services.BuildServiceProvider().GetRequiredService<ApplicationContext>();
            DbInitializer.Initialize(context);

            await app.Run();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();

            serviceCollection.AddSingleton<IConfigurationRoot>(configuration);            

            var connectionString = configuration.GetConnectionString("DatabaseConnection");
            serviceCollection.ConfigureDatabase(connectionString);

            serviceCollection.AddTransient<Application>();
        }
    }
}