using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ORMs.BLL.DI;

namespace ORMs.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);           

            Application app = services
                              .BuildServiceProvider()
                              .GetRequiredService<Application>();

            app.Run();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();            

            serviceCollection.AddSingleton<IConfigurationRoot>(configuration);
            serviceCollection.AddTransient<Application>();

            var connectionString = configuration.GetConnectionString("DatabaseConnection");

            serviceCollection.ConfigureDatabase(connectionString);
        }
    }
}