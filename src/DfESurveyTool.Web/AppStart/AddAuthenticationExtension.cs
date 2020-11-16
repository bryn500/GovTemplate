using DfESurveyTool.Web.Consts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Threading.Tasks;

namespace DfESurveyTool.Web.AppStart
{
    public static class AddAuthenticationExtension
    {
        public static void AddAzureADAuth(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(AzureADDefaults.AuthenticationScheme)
                .AddAzureAD(options => configuration.Bind("AzureAd", options));

            services.Configure<CookieAuthenticationOptions>(AzureADDefaults.CookieScheme,
                    options => { 
                        options.AccessDeniedPath = "/Account/AccessDenied";
                        options.Cookie.Name = CookieNames.AzureADLogin;
                    });

            services.Configure<OpenIdConnectOptions>(AzureADDefaults.OpenIdScheme, options =>
            {
                // For API Auth
                //options.Authority += "/v2.0/";
                //options.TokenValidationParameters.ValidateIssuer = true;

                // add name to User.Identity
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = "name"
                };

                // handle events
                options.Events.OnMessageReceived = OnMessageReceived;
            });
        }

        private static Task OnMessageReceived(MessageReceivedContext context)
        {
            // handle AAD errors
            if (!string.IsNullOrEmpty(context.ProtocolMessage.Error) &&
                !string.IsNullOrEmpty(context.ProtocolMessage.ErrorDescription) &&
                    context.ProtocolMessage.ErrorDescription.StartsWith(AzureADErrorCodes.NoAccessToSite))
            {
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                context.Response.Redirect("/Account/AccessRequest/");
                context.HandleResponse();
            }

            return Task.CompletedTask;
        }
    }
}
