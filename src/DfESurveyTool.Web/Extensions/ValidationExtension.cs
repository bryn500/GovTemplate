using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Linq;

namespace DfESurveyTool.Web.Extensions
{
    public static class ValidationExtension
    {
        public static bool FieldHasError<T>(this ViewDataDictionary<T> viewData, string fieldName)
        {
            bool? hasError = viewData?.ModelState[fieldName]?.Errors?.Any();

            return hasError.HasValue && hasError.Value;
        }
    }
}
