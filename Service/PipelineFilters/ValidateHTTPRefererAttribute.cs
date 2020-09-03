using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using System;

namespace Service.PipelineFilters
{
    public class ValidateHTTPRefererAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string referer = context.HttpContext.Request.Headers["Referer"].ToString();
            if (string.IsNullOrEmpty(referer))
            {
                context.Result = new ContentResult() { Content = "Access denied" };
            }
            else
            {
                Uri uri = new Uri(referer);

                string refererHost = uri.Host;
                string serverHost = context.HttpContext.Request.Host.Host;

                if (refererHost != serverHost)
                {
                    context.Result = new ContentResult() { Content = "Access denied" };
                }
            }

        }
    }
}
