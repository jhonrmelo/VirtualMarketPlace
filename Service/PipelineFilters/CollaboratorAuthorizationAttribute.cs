using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Service.Login.Collaborators;
using System;

namespace Service.PipelineFilters
{
    public class CollaboratorAuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        CollaboratorLoginService _loginService;
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _loginService = (CollaboratorLoginService)context.HttpContext.RequestServices.GetService(typeof(CollaboratorLoginService));

            CollaboratorModel client = _loginService.GetCollaborator();

            if (client is null)
            {
                context.Result = new ContentResult() { Content = "You don't have access" };
            }
        }
    }
}
