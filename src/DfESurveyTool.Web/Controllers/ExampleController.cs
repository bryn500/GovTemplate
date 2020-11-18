using DfESurveyTool.Web.Models.Example;
using Microsoft.AspNetCore.Mvc;

namespace DfESurveyTool.Web.Controllers
{
    [Route("example")]
    public class ExampleController : BaseController
    {
        [HttpGet("form")]
        public IActionResult FormExample()
        {
            ViewData["Title"] = "Example Form Validation";
            return View(new ExampleFormViewModel());
        }

        [HttpPost("form")]
        public IActionResult FormExample(ExampleFormViewModel model)
        {
            ViewData["Title"] = "Example Form Validation";

            if(!ModelState.IsValid)
            {
                ViewData["Title"] = "Error: " + ViewData["Title"];
                return View(model);
            }

            return View(model);
        }

        [HttpGet("form-success")]
        public IActionResult FormSuccess()
        {
            ViewData["Title"] = "Example Form Validation - Success";
            return View();
        }
    }
}
