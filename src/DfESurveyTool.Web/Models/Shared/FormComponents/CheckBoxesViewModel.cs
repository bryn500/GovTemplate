using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace DfESurveyTool.Web.Models.Shared.FormComponents
{
    public class CheckBoxesViewModel
    {
        public string Question { get; set; }

        public string Hint { get; set; }

        public IEnumerable<SelectListItem> CheckBoxes { get; set; }

        public bool HasError { get; set; }

        [BindProperty]
        public string[] Selected { get; set; }
    }
}
