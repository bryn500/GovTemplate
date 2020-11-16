using DfESurveyTool.Web.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DfESurveyTool.Web.AppStart
{
    public static class AddConfigRegistrationExtension
    {
        public static void AddConfigRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AzureAdConfig>(configuration.GetSection("AzureAd"));
            services.Configure<KeysConfig>(configuration.GetSection("Keys"));
        }
    }
}
