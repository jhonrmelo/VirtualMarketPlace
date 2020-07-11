using Repository.Newsletter;
using VirtualMarketPlace.Domain.Models;

namespace Service.Newsletter
{
    public class NewsletterService : INewsletterService
    {
        private INewsletterRepository _newsletterRepository;

        public NewsletterService(INewsletterRepository newsletterRepository)
        {
            _newsletterRepository = newsletterRepository;
        }

        public void Create(NewsletterEmail newsletterEmail)
        {
            _newsletterRepository.Create(newsletterEmail);
        }
    }
}
