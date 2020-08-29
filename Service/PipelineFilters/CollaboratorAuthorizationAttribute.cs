using Domain.Enums;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Service.Login.Collaborators;
using System;

namespace Service.PipelineFilters
{
    public class CollaboratorAuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        private EnumCollaboratorType _collaboratorTypeRequest;
        public CollaboratorAuthorizationAttribute(EnumCollaboratorType enumCollaboratorType = EnumCollaboratorType.Employee)
        {
            _collaboratorTypeRequest = enumCollaboratorType;
        }
        CollaboratorLoginService _loginService;
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _loginService = (CollaboratorLoginService)context.HttpContext.RequestServices.GetService(typeof(CollaboratorLoginService));

            CollaboratorModel collaborator = _loginService.GetCollaborator();

            if (collaborator is null)
            {
                context.Result = new RedirectToActionResult("Login", "CollaboratorHome", null);
            }
            else
            {
                if (collaborator.CollaboratorTypeId == (int)EnumCollaboratorType.Employee && _collaboratorTypeRequest == EnumCollaboratorType.Manager)
                {
                    context.Result = new ForbidResult();
                }
            }
        }
    }
}
