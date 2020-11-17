using Domain.Enums;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service.Collaborator;
using Service.PipelineFilters;
using System.Linq;
using X.PagedList;

namespace VirtualMarketPlace.Areas.Collaborator.Controllers
{
    [Area("Collaborator")]
    [CollaboratorAuthorization(EnumCollaboratorType.Manager)]
    public class CollaboratorController : Controller
    {
        private ICollaboratorService _collaboratorService;

        public CollaboratorController(ICollaboratorService collaboratorService)
        {
            _collaboratorService = collaboratorService;
        }
        public IActionResult Index(int? index)
        {
            IPagedList<CollaboratorModel> collaborators = _collaboratorService.GetPagedCollaborators(index);
            return View(collaborators);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.CollaboratorTypes = _collaboratorService.GetCollaboratorTypes().Select(collaboratorType => new SelectListItem(collaboratorType.Description, collaboratorType.Id.ToString()));
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] CollaboratorModel collaborator)
        {
            ModelState.Remove("Password");
            if (!_collaboratorService.IsCollaboratorEmailUnique(collaborator))
                ModelState.AddModelError("Email", "We alread have this e-mail in our database!");

            if (ModelState.IsValid)
            {
                _collaboratorService.Create(collaborator);
                TempData["MSG_S"] = "Collaborator created with success!";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.CollaboratorTypes = _collaboratorService.GetCollaboratorTypes().Select(collaboratorType => new SelectListItem(collaboratorType.Description, collaboratorType.Id.ToString()));
            return View(collaborator);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var collaborator = _collaboratorService.GetCollaborator(id);
            ViewBag.CollaboratorTypes = _collaboratorService.GetCollaboratorTypes().Select(collaboratorType => new SelectListItem(collaboratorType.Description, collaboratorType.Id.ToString()));
            return View(collaborator);
        }

        [HttpPost]
        public IActionResult Update([FromForm] CollaboratorModel collaborator)
        {
            ModelState.Remove("Password");

            if (!_collaboratorService.IsCollaboratorEmailUnique(collaborator))
                ModelState.AddModelError("Email", "We alread have this e-mail in our database!");

            if (ModelState.IsValid)
            {
                _collaboratorService.Update(collaborator);

                TempData["MSG_S"] = "Collaborator updated with success!";
                return RedirectToAction(nameof(Index));
            }

            return View(collaborator);
        }

        [HttpGet]
        [ValidateHTTPReferer]
        public IActionResult Delete(int id)
        {
            _collaboratorService.Delete(id);
            TempData["MSG_S"] = "Collaborator removed!";
            return Json(new { status = true });
        }

        [HttpGet]
        [ValidateHTTPReferer]
        public IActionResult CreatePassword(int id)
        {
            _collaboratorService.CreatePassword(id);
            return Json(new { status = true });
        }
    }
}