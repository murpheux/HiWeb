using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Http.Filters;
using System.Web.Mvc;

namespace HiWeb.Filters
{
    public class AppRequiresSSL : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpRequestBase req = filterContext.HttpContext.Request;
            HttpResponseBase res = filterContext.HttpContext.Response;

            //Check if we're secure or not and if we're on the local box
            //res.Redirect(url);
            if (!req.IsSecureConnection && !req.IsLocal)
            {
                //string url = req.Url.ToString().ToLower().Replace("http:", "https:");
                var builder = new UriBuilder(req.Url)
                {
                    Scheme = Uri.UriSchemeHttps,
                    Port = 443
                };
                res.Redirect(builder.Uri.ToString());
            }
            base.OnActionExecuting(filterContext);
        }
    }
}