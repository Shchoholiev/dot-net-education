using Microsoft.Extensions.DependencyInjection;
using NLayerArchitecture.BLL.Infrastructure;
using NLayerArchitecture.BLL.Services;
using NLayerArchitecture.DAL.Repository;

namespace NLayerArchitecture.BLL.DI
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<IRepository, JsonRepository>(provider => new JsonRepository("../file.json"));
            services.AddTransient<IStudentsService, StudentsService>();
            return services;
        }
    }
}
