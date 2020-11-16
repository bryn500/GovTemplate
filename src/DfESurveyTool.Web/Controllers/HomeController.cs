using DfESurveyTool.Web.Attributes.Action;
using DfESurveyTool.Web.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace DfESurveyTool.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [ResponseCache(CacheProfileName = "Default")]
        [ActiveHeaderItemFilter(ActiveHeaderItem.Home)]
        [HttpGet("")]
        public IActionResult Index()
        {
            MetaTags.Add(new KeyValuePair<string, string>("TestKey", "TestValue"));
            return View();
        }

        [ResponseCache(CacheProfileName = "Default")]
        [ActiveHeaderItemFilter(ActiveHeaderItem.Test)]
        [HttpGet("Test")]
        public IActionResult Test()
        {
            return View();
        }
    }
}
