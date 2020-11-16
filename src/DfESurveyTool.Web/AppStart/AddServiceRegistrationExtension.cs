using Joonasw.AspNetCore.SecurityHeaders;
using Microsoft.Extensions.DependencyInjection;

namespace DfESurveyTool.Web.AppStart
{
    public static class AddServiceRegistrationExtension
    {
        public static void AddServiceRegistration(this IServiceCollection services)
        {
            //services.AddScoped<IService, Service>();

            // Add service for generating nonces per request
            services.AddCsp(nonceByteAmount: 32);
        }
    }
}
