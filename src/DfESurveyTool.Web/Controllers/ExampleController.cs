using DfESurveyTool.Web.Attributes.Action;
using DfESurveyTool.Web.Config;
using DfESurveyTool.Web.Models.Example;
using DfESurveyTool.Web.Models.Shared.FormComponents;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DfESurveyTool.Web.Controllers
{
    [Route("example")]
    [ActiveHeaderItemFilter(ActiveHeaderItem.Example)]
    public class ExampleController : BaseController
    {
        [HttpGet("form")]
        public IActionResult Form()
        {
            ViewData["Title"] = "Example Form Validation";
            var model = new ExampleFormViewModel();
            SetExampleFormModel(model);
            return View(model);
        }

        [HttpPost("form")]
        public IActionResult Form(ExampleFormViewModel model)
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
            var radioErrors = ViewData?.ModelState[nameof(model.RadioQuestion) + "." + nameof(model.RadioQuestion.Selected)]?.Errors?.Any();
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

            var radioErrors2 = ViewData?.ModelState[nameof(model.RadioQuestion2) + "." + nameof(model.RadioQuestion2.Selected)]?.Errors?.Any();
            model.RadioQuestion2 = new RadioButtonsViewModel()
            {
                Question = "True or False?",
                Hint = "This is a hint",
                Radios = new List<SelectListItem>() {
                    new SelectListItem() {
                        Text = "Yes",
                        Value = "True"
                    },
                    new SelectListItem() {
                        Text = "No",
                        Value = "False"
                    },
                    new SelectListItem() {
                        Text = "Maybe",
                        Value = "Maybe"
                    }
                },
                HasError = radioErrors2.HasValue && radioErrors2.Value
            };

            var selectedCheckBoxes = model.CheckBoxQuestion.Selected;
            var checkBoxErrors = ViewData?.ModelState[nameof(model.CheckBoxQuestion) + "." + nameof(model.CheckBoxQuestion.Selected)]?.Errors?.Any();
            model.CheckBoxQuestion = new CheckBoxesViewModel()
            {
                Question = "True or False?",
                Hint = "This is a hint",
                CheckBoxes = new List<SelectListItem>() {
                    new SelectListItem() {
                        Text = "Yes",
                        Value = "True"
                    },
                    new SelectListItem() {
                        Text = "No",
                        Value = "False"
                    }
                },
                HasError = checkBoxErrors.HasValue && checkBoxErrors.Value
            };

            if (selectedCheckBoxes != null)
                foreach (var item in model.CheckBoxQuestion.CheckBoxes)
                    item.Selected = selectedCheckBoxes.Contains(item.Value);


            var selectedCheckBoxes2 = model.CheckBoxQuestion2.Selected;
            var checkBoxErrors2 = ViewData?.ModelState[nameof(model.CheckBoxQuestion2) + "." + nameof(model.CheckBoxQuestion2.Selected)]?.Errors?.Any();
            model.CheckBoxQuestion2 = new CheckBoxesViewModel()
            {
                Question = "True or False?",
                Hint = "This is a hint",
                CheckBoxes = new List<SelectListItem>() {
                    new SelectListItem() {
                        Selected = false,
                        Text = "Yes",
                        Value = "True"
                    },
                    new SelectListItem() {
                        Selected = false,
                        Text = "No",
                        Value = "False"
                    },
                    new SelectListItem() {
                        Selected = false,
                        Text = "Maybe",
                        Value = "Maybe"
                    }
                },
                HasError = checkBoxErrors2.HasValue && checkBoxErrors2.Value
            };

            if (selectedCheckBoxes2 != null)
                foreach (var item in model.CheckBoxQuestion2.CheckBoxes)
                    item.Selected = selectedCheckBoxes2.Contains(item.Value);

        }
    }
}
