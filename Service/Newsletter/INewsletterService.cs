﻿using VirtualMarketPlace.Domain.Models;

namespace Service.Newsletter
{
    public interface INewsletterService
    {
        void Create(NewsletterEmail newsletterEmail);
    }
}
