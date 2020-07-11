
using Microsoft.EntityFrameworkCore;
using VirtualMarketPlace.Domain.Models;

namespace VirtualMarketPlace.Repository.Database
{
    public class VirtualMarketPlaceContext : DbContext
    {
        public VirtualMarketPlaceContext(DbContextOptions<VirtualMarketPlaceContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<NewsletterEmail> NewsletterEmails { get; set; }
    }
}
