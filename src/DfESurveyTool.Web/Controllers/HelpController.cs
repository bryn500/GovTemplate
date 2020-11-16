using DfESurveyTool.Web.Config;
using DfESurveyTool.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using Microsoft.AspNetCore.Http.Features;
using DfESurveyTool.Web.Consts;

namespace DfESurveyTool.Web.Controllers
{
    [Route("help")]
    public class HelpController : BaseController
    {
        private readonly KeysConfig _keysConfig;

        public HelpController(IOptions<KeysConfig> keysConfig)
        {
            _keysConfig = keysConfig.Value;
        }

        [ResponseCache(CacheProfileName = "Default")]
        [HttpGet("privacy")]
        public IActionResult Privacy()
        {
            ViewData["Title"] = "Privacy";

            return View();
        }

        [HttpGet("cookies")]
        public IActionResult Cookies()
        {
            ViewData["Title"] = "Cookies";
            var consentFeature = HttpContext.Features.Get<ITrackingConsentFeature>();
            
            CookiePreferencesViewModel model = new CookiePreferencesViewModel()
            {
                Analytics = consentFeature.CanTrack
            };
            return View(model);
        }

        [HttpPost("cookies")]
        public IActionResult Cookies(CookiePreferencesViewModel model)
        {
            ViewData["Title"] = "Cookies";

            var consentFeature = HttpContext.Features.Get<ITrackingConsentFeature>();

            if (model.Analytics)
            {
                consentFeature.GrantConsent();
            }
            else
            {
                consentFeature.WithdrawConsent();                
                // Google analytics
                RemoveCookie(CookieNames.GA);
                RemoveCookie(CookieNames.GId);
                RemoveCookie($"{CookieNames.GTag}{_keysConfig.GoogleAnalyticsKey.Replace("-", "_")}");
                // Application insights
                RemoveCookie(CookieNames.AIUser);
                RemoveCookie(CookieNames.AISession);
            }

            return View(model);
        }

        [ResponseCache(CacheProfileName = "Default")]
        [HttpGet("cookie-details")]
        public IActionResult CookieDetails()
        {
            ViewData["Title"] = "Cookie Details";

            return View();
        }

        [ResponseCache(CacheProfileName = "Default")]
        [HttpGet("accessibility")]
        public IActionResult Accessibility()
        {
            ViewData["Title"] = "Accessibility";

            return View();
        }
    }
}