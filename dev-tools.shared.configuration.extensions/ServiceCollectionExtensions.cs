using Microsoft.Extensions.Configuration;

namespace infrastructure.configuration.extensions
{
    public static class ServiceCollectionExtensions
    {
        private static string ASPNETCORE_ENVIRONMENT_VAR_KEY = "ASPNETCORE_ENVIRONMENT";

        public static IConfiguration ConfigurationInitialize()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile(
                    $"appsettings.{Environment.GetEnvironmentVariable(ASPNETCORE_ENVIRONMENT_VAR_KEY)}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            return configuration;
        }
    }
}