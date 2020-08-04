using System.Collections.Generic;
using System.Linq;
using VirtualMarketPlace.Domain.Models;
using VirtualMarketPlace.Repository.Database;

namespace Repository.Newsletter
{
    public interface INewsletterRepository
    {
        void Create(NewsletterEmail newsletterEmail);
        List<NewsletterEmail> GetNewsletterEmails();
    }
}
