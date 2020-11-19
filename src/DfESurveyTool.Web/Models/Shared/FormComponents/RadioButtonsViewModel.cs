using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DfESurveyTool.Web.Models.Shared.FormComponents
{
    public class RadioButtonsViewModel
    {
        public string Question { get; set; }

        public string Hint { get; set; }

        public IEnumerable<SelectListItem> Radios { get; set; }

        public bool HasError { get; set; }

        [BindProperty, Required]
        public bool? Radio { get; set; }
    }
}
