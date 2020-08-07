using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Service.Login.Clients;
using System;
using VirtualMarketPlace.Domain.Models;

namespace Service.PipelineFilters
{
    public class ClientAuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        ClientLoginService _loginService;
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _loginService = (ClientLoginService)context.HttpContext.RequestServices.GetService(typeof(ClientLoginService));

            ClientModel client = _loginService.GetClient();

            if (client is null)
            {
                context.Result = new ContentResult() { Content = "You don't have access" };
            }
        }
    }
}
