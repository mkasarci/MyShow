using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;

namespace MyShow.Data.Extensions;
public static class ServicesExtensions
{
    public static void AddDataServices(this IServiceCollection services, IConfiguration config)
    {
        services.RegisterAssemblyPublicNonGenericClasses()
            .Where(c => c.Name.EndsWith("Repository"))
            .AsPublicImplementedInterfaces(ServiceLifetime.Scoped);

        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
    }
}
