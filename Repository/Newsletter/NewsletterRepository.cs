﻿using VirtualMarketPlace.Domain.Models;
using VirtualMarketPlace.Repository.Database;

namespace Repository.Newsletter
{
    public class NewsletterRepository : INewsletterRepository
    {
        private VirtualMarketPlaceContext _database;
        public NewsletterRepository(VirtualMarketPlaceContext database)
        {
            _database = database;
        }

        public void Create(NewsletterEmail newsletterEmail)
        {
            _database.Add(newsletterEmail);
            _database.SaveChanges();
        }
    }
}