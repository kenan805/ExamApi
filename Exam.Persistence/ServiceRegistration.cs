using Exam.Application.Repositories;
using Exam.Application.Repositories.Base;
using Exam.Persistence.Contexts;
using Exam.Persistence.Repositories;
using Exam.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Persistence;
public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ExamDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServer")));
        AddRepositories(services);
    }


    // Auto di register repositories 
    private static void AddRepositories(IServiceCollection services)
    {
        var genericInterfaceType = typeof(IRepository<>);

        var genericRepositoryAssembly = genericInterfaceType.Assembly;

        var allTypes = genericRepositoryAssembly.GetTypes();

        var interfaceTypes = new List<Type>();

        foreach (var type in allTypes)
        {
            interfaceTypes.AddRange(type.GetInterfaces()
                .Where(x => x.IsGenericType && x.GetGenericTypeDefinition() == genericInterfaceType));
        }

        foreach (var @interface in interfaceTypes)
        {
            var repoInterface = allTypes.First(x => x.IsAssignableTo(@interface));
            var repoImplementation = Assembly.GetExecutingAssembly().GetTypes().First(x => !x.IsInterface && repoInterface.IsAssignableFrom(x));

            services.AddScoped(repoInterface, repoImplementation);
        }
    }
}
