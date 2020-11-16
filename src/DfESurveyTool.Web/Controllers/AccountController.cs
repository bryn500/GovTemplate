using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DfESurveyTool.Web.Controllers
{
    [Route("Account")]
    public class AccountController : BaseController
    {
        [AllowAnonymous]
        [HttpGet("signout")]
        public IActionResult SignOut()
        {
            ViewData["Title"] = "Signed Out";
            return View();
        }

        [AllowAnonymous]
        [HttpGet("AccessDenied")]
        public IActionResult AccessDenied()
        {
            ViewData["Title"] = "Access Denied";
            return View();
        }

        [AllowAnonymous]
        [HttpGet("AccessRequest")]
        public IActionResult AccessRequest()
        {
            ViewData["Title"] = "Access Request";
            return View();
        }
    }
}