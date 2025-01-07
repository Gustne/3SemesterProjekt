

using Microsoft.Extensions.DependencyInjection;

namespace ExitSlip.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationDependency(this IServiceCollection services)
    {
        return services;
    }
}
