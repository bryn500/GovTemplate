using DfESurveyTool.Web.AppStart;
using DfESurveyTool.Web.Consts;
using Joonasw.AspNetCore.SecurityHeaders;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace DfESurveyTool.Web
{
    public class Startup
    {
        public static readonly ILoggerFactory Logging = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            // Get config options
            services.AddConfigRegistration(Configuration);

            // Configure database
            services.AddDatabase(Configuration, Logging, env);

            // Configure application services
            services.AddServiceRegistration();

            // Adds profiler service for performance checking
            services.AddMiniProfiler();

            // Adds response caching and compression
            services.AddCachingAndCompression();

            // Configure AAD
            services.AddAzureADAuth(Configuration);

            // Adds server side Application Insights
            services.AddApplicationInsightsTelemetry();

            // Configure cookie policy options
            services.ConfigureCookiePolicy();

            // Configure antiforgery token options
            services.AddAntiforgery(opts => opts.Cookie.Name = CookieNames.AntiForgery);

            // Add controllers + views instead of razor pages
            services.AddControllersWithViews();

            // Add/configure MVC
            services.AddMvc(options =>
            {
                // require user is logged in to access anything by default unless in dev
                if (env != "Development")
                    AuthOptions.AddAuthOptions(options);

                // Automatically add an anti-forgery token to any http request method that alters server state
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());

                // add cache profiles
                CacheProfiles.AddCacheProfiles(options);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Error pages
            app.UseErrorPages(env);

            // Enable Strict Transport Security with a 365 day caching period
            app.UseHsts(new HstsOptions(TimeSpan.FromDays(365), includeSubDomains: false, preload: false));

            // Redirect to https
            app.UseHttpsRedirection();

            // Add Content Security Policy + security headers
            app.UseSecurityHeaders(env);

            // Compress responses based on options from ConfigureServices
            app.UseResponseCompression();

            // setup site to serve static files
            app.UseStaticFileDefaults();

            // Cookie policy
            app.UseCookiePolicy();

            // use mini profiler in dev for performance checking
            if (env.IsDevelopment())
                app.UseMiniProfiler();

            // Matches request to an endpoint
            app.UseRouting();

            // Use cache profiles set in ConfigureServices
            app.UseResponseCaching();

            // AAD Auth
            app.UseAuthentication();
            app.UseAuthorization();

            // Execute the matched endpoint
            app.UseEndpoints(endpoints =>
            {
                // attribute routing
                endpoints.MapControllers();

                // Default contoller/action/id routing
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Home}/{action=Index}/{id?}");

                // AD pages
                endpoints.MapRazorPages();                
            });
        }
    }
}
