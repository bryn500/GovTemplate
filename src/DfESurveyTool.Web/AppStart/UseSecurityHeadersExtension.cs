using Joonasw.AspNetCore.SecurityHeaders;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Linq;
using System.Threading.Tasks;

namespace DfESurveyTool.Web.AppStart
{
    public static class UseSecurityHeadersExtension
    {
        private const string appInsights = "https://az416426.vo.msecnd.net";
        private const string appInsights2 = "https://dc.services.visualstudio.com";
        private const string googleAnalytics = "https://www.google-analytics.com";

        public static void UseSecurityHeaders(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCsp(csp =>
            {
                // Default policy for content loading
                csp.ByDefaultAllow
                    .FromSelf();

                // Allow JavaScript from:
                csp.AllowScripts
                     .AllowUnsafeEval() // js templates + google analytics todo: find a fix for this (mustache...)
                     .FromSelf()
                     .From(appInsights)
                     .AddNonce();

                // CSS allowed from:
                if (env.IsDevelopment())
                {
                    csp.AllowStyles
                    .AllowUnsafeInline()
                    .FromSelf();
                }
                else
                {
                    csp.AllowStyles
                    .FromSelf();
                }

                // Images allowed from:
                csp.AllowImages
                    .FromSelf()
                    .From(googleAnalytics);

                // Fonts allowed from:
                csp.AllowFonts
                    .FromSelf();

                // Contained iframes can be sourced from:
                csp.AllowFrames
                    .FromNowhere();

                // Disallow other sites to put this in an iframe:
                csp.AllowFraming
                    .FromNowhere(); // Block framing on other sites, equivalent to X-Frame-Options: Deny

                // Allow any connections to external domains:
                csp.AllowConnections
                    .ToSelf()
                    .To(appInsights2)
                    .To(googleAnalytics);

                // Allow object, embed, and applet sources from:
                csp.AllowPlugins
                    .FromNowhere();

                // Restricts the URLs which may be loaded as a Worker, SharedWorker or ServiceWorker.
                csp.AllowWorkers
                    .FromNowhere();

                // Restricts the URLs that application manifests can be loaded.
                csp.AllowManifest
                    .FromNowhere();

                csp.AllowAudioAndVideo
                    .FromNowhere();
            });

            // Add pre-CSP headers for older browser support
            app.Use(async (context, next) =>
            {
                context.Response.OnStarting(() =>
                {
                    if (context.Response.Headers.All(x => x.Key != "X-Frame-Options")) context.Response.Headers.Add("X-Frame-Options", "DENY");
                    if (context.Response.Headers.All(x => x.Key != "X-Xss-Protection")) context.Response.Headers.Add("X-Xss-Protection", "0");
                    if (context.Response.Headers.All(x => x.Key != "X-Content-Type-Options")) context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                    if (context.Response.Headers.All(x => x.Key != "Referrer-Policy")) context.Response.Headers.Add("Referrer-Policy", "same-origin");
                    return Task.CompletedTask;
                });

                await next();
            });
        }
    }
}
