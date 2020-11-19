using DfESurveyTool.Web.Models.Shared.FormComponents;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DfESurveyTool.Web.Models.Example
{
    public class ExampleFormViewModel
    {
        [BindProperty, Required, StringLength(maximumLength: 20, MinimumLength = 3)]
        public string Text { get; set; }

        public RadioButtonsViewModel RadioQuestion { get; set; } = new RadioButtonsViewModel();

        [BindProperty]
        public string[] Checkboxes { get; set; }

        [BindProperty]
        public int Day { get; set; }
        [BindProperty]
        public int Month { get; set; }
        [BindProperty]
        public int Year { get; set; }
    }
}
