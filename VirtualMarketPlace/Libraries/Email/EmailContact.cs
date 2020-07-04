using System.Net;
using System.Net.Mail;
using VirtualMarketPlace.Helpers;
using VirtualMarketPlace.Models;

namespace VirtualMarketPlace.Libraries.Email
{
    public class EmailContact
    {
        public static void SendContactByEmail(Contact contact)
        {
            //This is your personal password, if you change it dont put in github
            string password = "";

            SmtpClient smtpClient = new SmtpClient(Constants.SmtServer, Constants.SmtPort)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(Constants.PersonalEmail, password),
                EnableSsl = true
            };

            string messageBody = _getMessageBody(contact);

            MailMessage message = new MailMessage()
            {
                From = new MailAddress(Constants.PersonalEmail),
                Subject = "Contact - Jonathan's Market Place",
                Body = messageBody,
                IsBodyHtml = true
            };

            message.To.Add(Constants.PersonalEmail);

            smtpClient.Send(message);

        }

        private static string _getMessageBody(Contact contact)
        {
            string messageBody = $@"<h2>Contact - Market Place </h2>
                                     <b>Name: </b> {contact.Name}  <br/>
                                     <b>E-mail: </b> {contact.Email} <br/>
                                     <b>Text: </b> {contact.Message} <br>
                                     Email Sent automatically by our website, do not answer it";
            return messageBody;
        }
    }
}
