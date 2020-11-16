using DfESurveyTool.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DfESurveyTool.Web.AppStart
{
    public static class AddDatabaseExtension
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration, ILoggerFactory logging, string env)
        {
            var connectionString = configuration.GetConnectionString("Connection");
            services.AddDbContext<DfESurveyToolDbContext>(options =>
            {
                options.UseSqlServer(connectionString);

                if (env == "Development")
                {
                    options.UseLoggerFactory(logging);
                }
            });
        }
    }
}
