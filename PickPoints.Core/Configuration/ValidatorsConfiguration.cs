using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using PickPoints.Core.Models;
using PickPoints.Core.Validators;

namespace PickPoints.Core.Configuration
{
    public static class ValidatorsConfiguration
    {
        public static IServiceCollection ConfigureValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<CreateOrderRequest>, CreateOrderRequestValidator>();
            services.AddTransient<IValidator<UpdateOrderRequest>, UpdateOrderRequestValidator>();

            services.AddFluentValidation();
            return services;
        }
    }
}
