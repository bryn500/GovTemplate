using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DfESurveyTool.Web.Attributes.Action
{
    public class ActiveHeaderItemFilterAttribute : ActionFilterAttribute
    {
        private readonly string _name;

        public ActiveHeaderItemFilterAttribute(string name)
        {
            _name = name;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            if (context.Controller is Controller controller)
            {
                controller.ViewBag.ActiveHeaderItem = _name;
            }
        }
    }
}
