using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace infrastructure.fluentvalidation.extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFluentValidationExt<T>(this IServiceCollection services) where T : IValidator
        {
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblyContaining<T>();

            return services;
        }
    }
}