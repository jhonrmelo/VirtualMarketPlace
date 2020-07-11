using Microsoft.AspNetCore.Mvc;
using Service.Newsletter;
using Service.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VirtualMarketPlace.Domain.Models;
using VirtualMarketPlace.Models;

namespace VirtualMarketPlace.Controllers
{
    public class HomeController : Controller
    {
        private IClientService _clienteService;
        private INewsletterService _newsletterService;
        public HomeController(IClientService clientService, INewsletterService newsletterService)
        {
            _clienteService = clientService;
            _newsletterService = newsletterService;
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

        public IActionResult Login()
        {
            return View();
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