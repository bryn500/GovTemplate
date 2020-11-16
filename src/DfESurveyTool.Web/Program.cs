using DfESurveyTool.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace DfESurveyTool.Web
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            // DB migrations and Data seeding
            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;

                var hostingEnv = serviceProvider.GetRequiredService<IWebHostEnvironment>();

                using (var context = serviceProvider.GetRequiredService<DfESurveyToolDbContext>())
                {
                    context.Database.Migrate();

                    await DataSeed.AddRequiredData(context);

                    if (hostingEnv.IsDevelopment())
                    {
                        await DataSeed.AddData(context);
                    }
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    if (!context.HostingEnvironment.IsDevelopment())
                    {
                        var builtConfig = config.Build();

                        // For key vault
                        //var azureServiceTokenProvider = new AzureServiceTokenProvider();
                        //var keyVaultClient = new KeyVaultClient(
                        //    new KeyVaultClient.AuthenticationCallback(
                        //        azureServiceTokenProvider.KeyVaultTokenCallback));

                        //config.AddAzureKeyVault(
                        //    $"https://{builtConfig["KeyVaultName"]}.vault.azure.net/",
                        //    keyVaultClient,
                        //    new DefaultKeyVaultSecretManager());
                    }
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(serverOptions =>
                    {
                        serverOptions.AddServerHeader = false;
                    })
                    .UseStartup<Startup>();
                });
    }
}
