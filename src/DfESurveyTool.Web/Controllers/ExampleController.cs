using DfESurveyTool.Web.Models.Example;
using DfESurveyTool.Web.Models.Shared.FormComponents;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace DfESurveyTool.Web.Controllers
{
    [Route("example")]
    public class ExampleController : BaseController
    {
        [HttpGet("form")]
        public IActionResult FormExample()
        {
            ViewData["Title"] = "Example Form Validation";
            var model = new ExampleFormViewModel();
            SetExampleFormModel(model);
            return View(model);
        }

        [HttpPost("form")]
        public IActionResult FormExample(ExampleFormViewModel model)
        {
            ViewData["Title"] = "Example Form Validation";

            if (!ModelState.IsValid)
            {
                ViewData["Title"] = "Error: " + ViewData["Title"];
                SetExampleFormModel(model);
                return View(model);
            }

            return RedirectToAction("FormSuccess");
        }

        [HttpGet("form-success")]
        public IActionResult FormSuccess()
        {
            ViewData["Title"] = "Example Form Validation - Success";
            return View();
        }

        public void SetExampleFormModel(ExampleFormViewModel model)
        {
            var radioErrors = ViewData?.ModelState[nameof(model.RadioQuestion) + "." + nameof(model.RadioQuestion.Radio)]?.Errors?.Any();
            model.RadioQuestion = new RadioButtonsViewModel()
            {
                Question = "Yes or No?",
                Hint = "This is a hint",
                Radios = new List<SelectListItem>() {
                    new SelectListItem() {
                        Selected = false,
                        Text = "Yes",
                        Value = "True"
                    },
                    new SelectListItem() {
                        Selected = false,
                        Text = "No",
                        Value = "False"
                    }
                },
                HasError = radioErrors.HasValue && radioErrors.Value
            };

            if (model.RadioQuestion.Radio.HasValue)
            {
                foreach (var item in model.RadioQuestion.Radios)
                    item.Selected = item.Value == model.RadioQuestion.Radio.Value.ToString();
            }
        }
    }
}
