using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PickPoints.Infrastructure.Data;

namespace PickPoints.API.Configuration
{
    public static class DbContextConfiguration
    {
        public static IServiceCollection ConfigureDBContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("PickPointsConnection");
            services.AddDbContext<PickPointsDbContext>(options => options.UseNpgsql(connectionString));
            return services;
        }

        public static IApplicationBuilder EnsureMigration(this IApplicationBuilder app)
        {
            using (IServiceScope serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<PickPointsDbContext>();
                context.Database.Migrate();
            }
            return app;
        }
    }
}
