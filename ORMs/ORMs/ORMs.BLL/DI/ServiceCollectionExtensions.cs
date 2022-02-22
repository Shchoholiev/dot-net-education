using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ORMs.BLL.Infrastructure;
using ORMs.BLL.Services;
using ORMs.Core.Entities;
using ORMs.DAL;
using ORMs.DAL.EF;
using ORMs.DAL.IGenericRepository;

namespace ORMs.BLL.DI
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureDatabase(this IServiceCollection services, string connectionString)
        {

            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(connectionString));

            //services.AddTransient<IGenericRepository<Student>, StudentsADORepository>(provider =>
            //                                                   new StudentsADORepository(connectionString));

            services.AddTransient<IGenericRepository<Student>, StudentsDapperRepository>(provider =>
                                                               new StudentsDapperRepository(connectionString));

            //services.AddTransient<IGenericRepository<Student>, GenericRepository<Student>>();

            services.AddTransient<IStudentsService, StudentsService>();
            
            return services;
        }
    }
}
