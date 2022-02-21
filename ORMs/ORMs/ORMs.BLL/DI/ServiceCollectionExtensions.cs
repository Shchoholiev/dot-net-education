using Microsoft.Extensions.DependencyInjection;
using ORMs.BLL.Infrastructure;
using ORMs.BLL.Services;
using ORMs.Core.Entities;
using ORMs.DAL;
using ORMs.DAL.Repository;

namespace ORMs.BLL.DI
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            //var connectionString = @"server=(LocalDb)\MSSQLLocalDB;database=Store;integrated security=True;
            //        MultipleActiveResultSets=True;App=EntityFramework;";

            //services.AddDbContext<ApplicationContext>(options =>
            //    options.UseSqlServer(connectionString));

            //services.AddTransient<IRepository, JsonRepository>(provider => new JsonRepository("../file.json"));
            services.AddTransient<IGenericRepository<Student>, StudentsADORepository>(provider => new StudentsADORepository(""));
            services.AddTransient<IStudentsService, StudentsService>();
            return services;
        }
    }
}
