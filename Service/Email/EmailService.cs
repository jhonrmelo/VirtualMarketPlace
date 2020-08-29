using Domain.Models;
using Microsoft.Extensions.Configuration;
using Service.Email;
using System.Net.Mail;
using VirtualMarketPlace.Repository.Migrations;
using VirtualMarketPlace.ViewModels;

namespace VirtualMarketPlace.Service.Email
{
    public class EmailService : IEmailService
    {
        private SmtpClient _smtpClient;
        private IConfiguration _configuration;

        public EmailService(SmtpClient smtpClient, IConfiguration configuration)
        {
            _smtpClient = smtpClient;
            _configuration = configuration;
        }
        public void SendContactByEmail(ContactViewModel contact)
        {
            string messageBody = _getMessageBody(contact);
            string email = _configuration.GetValue<string>("Email:ProviderEmail");

            MailMessage message = new MailMessage()
            {
                From = new MailAddress(email),
                Subject = "Contact - Jonathan's Market Place",
                Body = messageBody,
                IsBodyHtml = true
            };
            message.To.Add(email);

            _smtpClient.Send(message);

        }
        private string _getMessageBody(ContactViewModel contact)
        {
            string messageBody = $@"<h2>Contact - Market Place </h2>
                                     <b>Name: </b> {contact.Name}  <br/>
                                     <b>E-mail: </b> {contact.Email} <br/>
                                     <b>Text: </b> {contact.Message} <br>
                                     Email Sent automatically by our website, do not answer it";
            return messageBody;
        }

        public void SendPassword(CollaboratorModel collaborator)
        {
            string messageBody = $@"<h1>Password - Market Place - {collaborator.Name} </h1>
                                       <h2> Your password to access our market place is:</h2>
                                        <h3>{collaborator.Password} </h3>";

            MailMessage message = new MailMessage()
            {
                From = new MailAddress(_configuration.GetValue<string>("Email:ProviderEmail")),
                Subject = "Password - Jonathan's Market Place",
                Body = messageBody,
                IsBodyHtml = true
            };

            message.To.Add(collaborator.Email);

            _smtpClient.Send(message);
        }
    }
}
