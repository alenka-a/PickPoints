using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace PickPoints.Core.Configuration
{
    public static class MappersConfiguration
    {
        public static IServiceCollection ConfigureMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
