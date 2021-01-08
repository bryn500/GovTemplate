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
            model.RadioQuestion = new OptionsViewModel()
            {
                Question = "Yes or No?",
                Hint = "This is a hint",
                Options = new List<SelectListItem>() {
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
                }
            };

            model.RadioQuestion2 = new OptionsViewModel()
            {
                Question = "True or False?",
                Hint = "This is a hint",
                Options = new List<SelectListItem>() {
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
                }
            };

            model.CheckBoxQuestion = new OptionsViewModel()
            {
                Question = "True or False?",
                Hint = "This is a hint",
                Options = new List<SelectListItem>() {
                    new SelectListItem() {
                        Text = "Yes",
                        Value = "True"
                    },
                    new SelectListItem() {
                        Text = "No",
                        Value = "False"
                    }
                }
            };

            model.CheckBoxQuestion2 = new OptionsViewModel()
            {
                Question = "True or False?",
                Hint = "This is a hint",
                Options = new List<SelectListItem>() {
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
                }
            };

            model.SelectQuestion = new OptionsViewModel()
            {
                Question = "Select your option",
                Hint = "This is a hint",
                Options = new List<SelectListItem>() {
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
                }
            };
        }
    }
}
