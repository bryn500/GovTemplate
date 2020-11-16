using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DfESurveyTool.Web.Controllers
{
    [AllowAnonymous]
    [ResponseCache(CacheProfileName = "None")]
    [Route("[controller]")]
    public class ErrorController : BaseController
    {
        public ErrorController()
        {
        }

        [HttpGet("ServerError")]
        public IActionResult ServerError()
        {
            ViewData["Title"] = "Sorry, there is a problem with the service";
            return View();
        }

        [HttpGet("Status404")]
        public IActionResult Status404()
        {
            ViewData["Title"] = "Page not found";
            return View();
        }
    }
}
