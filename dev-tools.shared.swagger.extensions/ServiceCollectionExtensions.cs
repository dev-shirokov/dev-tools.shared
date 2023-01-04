using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace shared.swagger.extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSwaggerExt(this IServiceCollection services, string versionName, string title, string? description = null)
        {
            var xmlFilename = $"{Assembly.GetCallingAssembly().GetName().Name}.xml";

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = versionName,
                    Title = title,
                    Description = description,
                    /*
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Example Contact",
                        Url = new Uri("https://example.com/contact")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Example License",
                        Url = new Uri("https://example.com/license")
                    } 
                    */
                });

                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            return services;
        }
    }
}