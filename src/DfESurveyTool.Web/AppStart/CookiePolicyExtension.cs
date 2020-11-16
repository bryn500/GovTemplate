using DfESurveyTool.Web.Consts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DfESurveyTool.Web.AppStart
{
    public static class CookiePolicyExtension
    {
        public static void ConfigureCookiePolicy(this IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.Lax;
                options.Secure = CookieSecurePolicy.Always;
                options.ConsentCookie.Name = CookieNames.CookieConsent;
            });
        }
    }
}
