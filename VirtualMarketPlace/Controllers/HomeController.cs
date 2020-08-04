using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Service.Login;
using Service.Newsletter;
using Service.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VirtualMarketPlace.Domain.Models;
using VirtualMarketPlace.Domain.ViewModels;
using VirtualMarketPlace.Models;

namespace VirtualMarketPlace.Controllers
{
    public class HomeController : Controller
    {
        private IClientService _clienteService;
        private INewsletterService _newsletterService;
        private ILoginService _loginservice;
        public HomeController(IClientService clientService, INewsletterService newsletterService, ILoginService loginService)
        {
            _clienteService = clientService;
            _newsletterService = newsletterService;
            _loginservice = loginService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index([FromForm] NewsletterEmail newsletter)
        {
            if (ModelState.IsValid)
            {
                _newsletterService.Create(newsletter);

                TempData["MSG_S"] = "E-mail sucessefully registered! Now You'll receive our newsletter!";

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }
        public IActionResult Contact()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ControlPanel()
        {
            Client client = _loginservice.GetClient();

            if (!(client is null))
            {
                return new ContentResult() { Content = $"Has Access => {client.Id} - {client.Email}" };
            }

            return new ContentResult() { Content = $"You don't have access" };
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login([FromForm]LoginViewModel login)
        {
            Client loggedClient = _clienteService.Login(login.Email, login.Password);

            if (!(loggedClient is null))
            {
                _loginservice.Login(loggedClient);

                return new RedirectResult(Url.Action(nameof(ControlPanel)));
            }

            login.LoginReturn = new LoginReturnViewModel(true, "Invalid Email and/or password.");

            return View(login);
        }

        [HttpPost]
        public IActionResult CreateUser([FromForm]Client client)
        {
            if (ModelState.IsValid)
            {
                _clienteService.Create(client);

                TempData["MSG_S"] = "The register was realized!";

                return RedirectToAction(nameof(CreateUser));
            }

            return View();
        }
        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }
        public IActionResult ShoppingCart()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendContact(Contact contact)
        {
            try
            {
                //  EmailContact.SendContactByEmail(contact);
                var returnContact = new ContactEmailReturn();

                var lstMessages = new List<ValidationResult>();
                var context = new ValidationContext(contact);
                bool isValid = Validator.TryValidateObject(contact, context, lstMessages, true);

                if (isValid)
                {
                    returnContact.IsMessageSent = true;
                    returnContact.ReturnMessage = "Message sent Sucessefully!";
                    returnContact.Contact = contact;
                }
                else
                {
                    StringBuilder sbMessages = new StringBuilder();
                    foreach (var validationMessage in lstMessages)
                    {
                        sbMessages.Append(validationMessage.ErrorMessage + "<br/>");
                    }

                    returnContact.Contact = contact;
                    returnContact.IsMessageSent = false;
                    returnContact.HasException = true;
                    returnContact.ReturnMessage = sbMessages.ToString();
                }

                return View("Contact", returnContact);
            }
            catch (Exception)
            {
                var returnContact = new ContactEmailReturn()
                {
                    IsMessageSent = false,
                    HasException = true,
                    ReturnMessage = "We are having problems to sent your message, try again later!"
                };
                return View("Contact", returnContact);
            }

        }

    }
}