using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using System.IO.Compression;

namespace DfESurveyTool.Web.AppStart
{
    public static class AddCachingAndCompressionExtension
    {
        public static void AddCachingAndCompression(this IServiceCollection services)
        {
            // Configure Compression level
            services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Fastest);

            // Add Response compression services
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<BrotliCompressionProvider>();
                options.Providers.Add<GzipCompressionProvider>();
                options.EnableForHttps = true;

                // Don't compress dynamic responses i.e html/json get requests (Crime/Breach vulnerability)
                options.MimeTypes = new[] {
                    "text/css",
                    "application/javascript",
                    "image/svg+xml"
                };
            });

            // Add response caching
            services.AddResponseCaching();
        }
    }
}
