using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;

namespace MyShow.Core.Extensions;
public static class ServicesExtensions
{
    public static void AddCoreServices(this IServiceCollection services)
    {
        services.RegisterAssemblyPublicNonGenericClasses()
                  .Where(c => c.Name.EndsWith("Action"))
                  .AsPublicImplementedInterfaces(ServiceLifetime.Scoped);
    }
}
