using DfESurveyTool.Web.Models.Shared.FormComponents;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DfESurveyTool.Web.Models.Example
{
    public class ExampleFormViewModel
    {
        [BindProperty, Required(ErrorMessage = "Enter your '...'"), StringLength(maximumLength: 20, MinimumLength = 3)]
        public string Text { get; set; }

        public OptionsViewModel RadioQuestion { get; set; }
        [BindProperty, Required(ErrorMessage = "Choose a '...'")]
        public string Radio1 { get; set; }

        public OptionsViewModel RadioQuestion2 { get; set; }
        [BindProperty, Required(ErrorMessage = "Choose a '...'")]
        public string Radio2 { get; set; }        
        

        public OptionsViewModel CheckBoxQuestion { get; set; }
        [BindProperty, Required(ErrorMessage = "Choose a '...'")]
        public string[] CheckBox1 { get; set; }

        public OptionsViewModel CheckBoxQuestion2 { get; set; }
        [BindProperty]
        public string[] CheckBox2 { get; set; }

        public OptionsViewModel SelectQuestion { get; set; }
        [BindProperty, Required(ErrorMessage = "Select an '...'")]
        public string Select1 { get; set; }


        //[BindProperty]
        //public int Day { get; set; }
        //[BindProperty]
        //public int Month { get; set; }
        //[BindProperty]
        //public int Year { get; set; }
    }
}
