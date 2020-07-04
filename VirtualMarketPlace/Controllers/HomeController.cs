using Microsoft.AspNetCore.Mvc;
using System;
using VirtualMarketPlace.Libraries.Email;
using VirtualMarketPlace.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text;

namespace VirtualMarketPlace.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
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
                        sbMessages.Append(validationMessage.ErrorMessage);
                    }

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