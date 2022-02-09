using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyShow.Data;
using NetCore.AutoRegisterDi;
using System.Reflection;

namespace MyShow.Core.Extensions;
public static class ServicesExtensions
{
    public static void AddCoreServices(this IServiceCollection services, IConfiguration config)
    {
        services
            .RegisterAssemblyPublicNonGenericClasses(Assembly.GetExecutingAssembly(), typeof(AppDbContext).Assembly)
            .Where(c => c.Name.EndsWith("Repository")
                        || c.Name.EndsWith("Action")
                        || c.Name.EndsWith("Queries"))
            .AsPublicImplementedInterfaces(ServiceLifetime.Scoped);

        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
    }
}
