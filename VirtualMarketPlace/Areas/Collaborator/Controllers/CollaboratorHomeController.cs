using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Service.Collaborator;
using Service.Login.Collaborators;
using Service.PipelineFilters;
using VirtualMarketPlace.Domain.ViewModels;

namespace VirtualMarketPlace.Areas.Collaborator.Controllers
{
    [Area("Collaborator")]
    public class CollaboratorHomeController : Controller
    {
        ICollaboratorService _collaboratorService;
        ICollaboratorLoginService _collaboratorLoginService;

        public CollaboratorHomeController(ICollaboratorService collaboratorService, ICollaboratorLoginService collaboratorLoginService)
        {
            _collaboratorService = collaboratorService;
            _collaboratorLoginService = collaboratorLoginService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Logout()
        {
            _collaboratorLoginService.Logout();

            return RedirectToAction("Login", "Home");
        }

        [HttpPost]
        public IActionResult Login([FromForm]LoginViewModel login)
        {
            CollaboratorModel loggedCollaborator = _collaboratorService.Login(login.Email, login.Password);

            if (!(loggedCollaborator is null))
            {
                _collaboratorLoginService.Login(loggedCollaborator);

                return new RedirectResult(Url.Action(nameof(ControlPanel)));
            }

            login.LoginReturn = new LoginReturnViewModel(true, "Invalid Email and/or password.");

            return View(login);
        }

        [CollaboratorAuthorization]
        public IActionResult ControlPanel()
        {
            return View();
        }

        public IActionResult RecoverPassword()
        {
            return View();
        }

        public IActionResult CreatePassword()
        {
            return View();
        }
    }
}