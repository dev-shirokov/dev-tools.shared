using Microsoft.AspNetCore.Builder;

namespace shared.swagger.extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseSwaggerExt(this IApplicationBuilder app)
    {
        app.UseSwagger(options =>
        {
            options.SerializeAsV2 = true;
        });
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            //options.RoutePrefix = string.Empty;
        });

        return app;
    }
}