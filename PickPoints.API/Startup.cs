using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PickPoints.API.Configuration;
using PickPoints.API.Filters;
using PickPoints.API.Middlewares;
using PickPoints.Core.Repositories.Interfaces;
using PickPoints.Core.Services;
using PickPoints.Core.Services.Interfaces;
using PickPoints.Infrastructure.Data.Repositories;
using PickPoints.Core.Configuration;

namespace PickPoints.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(opt =>
            {
                opt.Filters.Add(typeof(ValidateModelAttribute));
            });
            services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressModelStateInvalidFilter = true;
                });
            services.ConfigureValidators();
            services.AddSwaggerDocumentation();
            services.ConfigureDBContext(Configuration);
            services.ConfigureMappers();

            services.AddScoped<IPostampRepository, PostampRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPostampService, PostampService>();
            services.AddScoped<IOrdersService, OrdersService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseMiddleware<ExceptionHandlerMiddleware>();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwaggerDocumentation();
            app.EnsureMigration();
        }
    }
}
