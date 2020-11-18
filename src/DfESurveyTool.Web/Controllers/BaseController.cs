using DfESurveyTool.Web.Models.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;

namespace DfESurveyTool.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        public List<KeyValuePair<string, string>> MetaTags { get; set; } = new List<KeyValuePair<string, string>>();

        public List<Link> BreadCrumbs { get; set; } = new List<Link>()
        {
            new Link("Home", "/")
        };

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewBag.MetaTags = MetaTags;
            ViewBag.BreadCrumbs = BreadCrumbs;

            base.OnActionExecuting(context);
        }

        /// <summary>  
        /// Send with the response to the client an instruction to add a cookie  
        /// </summary>  
        /// <param name="key">key (unique indentifier)</param>  
        /// <param name="value">value to store in cookie object</param>  
        /// <param name="expireTime">expiration time</param>  
        public void SetCookie(string key, string value, DateTimeOffset? expireTime, bool essential = false)
        {
            CookieOptions option = new CookieOptions() {
                IsEssential = essential
            };

            if (expireTime.HasValue)
                option.Expires = expireTime.Value;
            else
                option.Expires = DateTimeOffset.Now.AddMilliseconds(10);

            Response.Cookies.Append(key, value, option);
        }

        /// <summary>  
        /// Send with the response to the client an instruction to delete the cookie with the specified key  
        /// </summary>  
        /// <param name="key">Key</param>  
        public void RemoveCookie(string key)
        {
            Response.Cookies.Delete(key);
        }
    }
}
