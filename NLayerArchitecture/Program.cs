using NLayerArchitecture.UI;
using Microsoft.Extensions.DependencyInjection;
using NLayerArchitecture.BLL.DI;

namespace NLayerArchitecture
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Application app = new ServiceCollection()
                              .ConfigureServices()
                              .AddTransient<Application>()
                              .BuildServiceProvider()
                              .GetRequiredService<Application>();

            app.Run();
        }
    }
}