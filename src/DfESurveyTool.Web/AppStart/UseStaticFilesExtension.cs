using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System;

namespace DfESurveyTool.Web.AppStart
{
    public static class UseStaticFilesExtension
    {
        public static void UseStaticFileDefaults(this IApplicationBuilder app)
        {
            app.UseStaticFiles(new StaticFileOptions()
            {
                OnPrepareResponse = (context) =>
                {
                    // add cache control header to static resources
                    var headers = context.Context.Response.GetTypedHeaders();
                    headers.CacheControl = new CacheControlHeaderValue()
                    {
                        MaxAge = TimeSpan.FromDays(365),
                        Public = true
                    };
                }
            });
        }
    }
}
