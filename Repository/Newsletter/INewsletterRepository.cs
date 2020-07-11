using VirtualMarketPlace.Domain.Models;

namespace Repository.Newsletter
{
    public interface INewsletterRepository
    {
        void Create(NewsletterEmail newsletterEmail);
    }
}
