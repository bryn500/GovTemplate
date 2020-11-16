using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace DfESurveyTool.Web.AppStart
{
    public static class UseErrorPagesExtension
    {
        public static void UseErrorPages(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error/ServerError");
                app.UseStatusCodePagesWithReExecute("/Error/Status404");
            }
        }
    }
}
