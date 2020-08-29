using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using VirtualMarketPlace.ViewModels;

namespace Service.Email
{
    public interface IEmailService
    {
        void SendContactByEmail(ContactViewModel contact);
        void SendPassword(CollaboratorModel collaborator);
    }
}
