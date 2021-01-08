using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace DfESurveyTool.Web.Models.Shared.FormComponents
{
    public class OptionsViewModel
    {
        public string Question { get; set; }

        public string Hint { get; set; }

        public IEnumerable<SelectListItem> Options { get; set; }
    }
}
