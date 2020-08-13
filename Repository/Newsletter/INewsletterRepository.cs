using System.Collections.Generic;
using System.Linq;
using VirtualMarketPlace.Domain.Models;
using VirtualMarketPlace.Repository.Database;

namespace Repository.Newsletter
{
    public interface INewsletterRepository
    {
        void Create(NewsletterEmailModel newsletterEmail);
        List<NewsletterEmailModel> GetNewsletterEmails();
    }
}
