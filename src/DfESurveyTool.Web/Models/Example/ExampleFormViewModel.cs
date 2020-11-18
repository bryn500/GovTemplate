using System.ComponentModel.DataAnnotations;

namespace DfESurveyTool.Web.Models.Example
{
    public class ExampleFormViewModel
    {
        public string Text { get; set; }
        [Required]
        public bool? Radio { get; set; }
        public string[] Checkboxes { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
}
