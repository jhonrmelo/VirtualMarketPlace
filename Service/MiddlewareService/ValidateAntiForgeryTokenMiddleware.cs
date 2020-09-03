using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;

using System.Threading.Tasks;

namespace Service.MiddlewareService
{
    public class ValidateAntiForgeryTokenMiddleware
    {
        private RequestDelegate _next;
        private IAntiforgery _antiforgery;

        public ValidateAntiForgeryTokenMiddleware(RequestDelegate next, IAntiforgery antiforgery)
        {
            _next = next;
            _antiforgery = antiforgery;
        }

        //Method called when an request is called
        public async Task Invoke(HttpContext context)
        {
            //The way to validate token in post requests
            if (HttpMethods.IsPost(context.Request.Method))
            {
                await _antiforgery.ValidateRequestAsync(context);
            }

            await _next(context);
        }
    }
}
