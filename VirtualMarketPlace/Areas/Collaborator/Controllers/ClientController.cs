using Microsoft.AspNetCore.Mvc;

using Service.PipelineFilters;
using Service.User;

using System;

using VirtualMarketPlace.Domain.Models;

using X.PagedList;

namespace VirtualMarketPlace.Areas.Collaborator.Controllers
{
    [Area("Collaborator")]
    [CollaboratorAuthorization]
    public class ClientController : Controller
    {
        private IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }
        public IActionResult Index(int? page, string searchName, string searchEmail)
        {
            IPagedList<ClientModel> listClients = _clientService.GetPagedClients(page, searchName, searchEmail);
            return View(listClients);
        }
        [HttpGet]
        [ValidateHTTPReferer]
        public IActionResult ChangeClientStatus(int id)
        {
            try
            {
                _clientService.ChangeStatus(id);
                TempData["MSG_S"] = "Client status changed with success!";
                return Json(new { status = true });
            }
            catch (Exception)
            {
                return Json(new { status = false });
            }
        }
    }
}
