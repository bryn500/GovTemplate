using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace DfESurveyTool.Web.AppStart
{
    public static class AuthOptions
    {
        public static void AddAuthOptions(MvcOptions options)
        {
            var policy = new AuthorizationPolicyBuilder()
                                    .RequireAuthenticatedUser()
                                    .Build();

            options.Filters.Add(new AuthorizeFilter(policy));
        }
    }
}
