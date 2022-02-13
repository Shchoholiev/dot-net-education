using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NLayerArchitecture.BLL.Infrastructure;
using NLayerArchitecture.BLL.Services;
using NLayerArchitecture.DAL.EF;
using NLayerArchitecture.DAL.Repository;

namespace NLayerArchitecture.BLL.DI
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            var connectionString = @"server=(LocalDb)\MSSQLLocalDB;database=Store;integrated security=True;
                    MultipleActiveResultSets=True;App=EntityFramework;";

            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(connectionString));

            //services.AddTransient<IRepository, JsonRepository>(provider => new JsonRepository("../file.json"));
            services.AddTransient<IRepository, SqlRepository>();
            services.AddTransient<IStudentsService, StudentsService>();
            return services;
        }
    }
}
