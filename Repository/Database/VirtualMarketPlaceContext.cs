
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using VirtualMarketPlace.Domain.Models;

namespace VirtualMarketPlace.Repository.Database
{
    public class VirtualMarketPlaceContext : DbContext
    {
        public VirtualMarketPlaceContext(DbContextOptions<VirtualMarketPlaceContext> options) : base(options) { }

        public DbSet<ClientModel> Clients { get; set; }
        public DbSet<NewsletterEmailModel> NewsletterEmails { get; set; }
        public DbSet<CollaboratorTypeModel> CollaboratorTypes { get; set; }
        public DbSet<CollaboratorModel> Collaborators { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CollaboratorTypeModel>().HasData(
                 new CollaboratorTypeModel()
                 {
                     Id = 1,
                     Description = "Manager"
                 },
                 new CollaboratorTypeModel()
                 {
                     Id = 2,
                     Description = "Employee"
                 }
           );

            modelBuilder.Entity<CollaboratorModel>().HasData(
                new CollaboratorModel()
                {
                    Id = 1,
                    Email = "Manager@MarketPlace.com",
                    Password = "123@123",
                    CollaboratorTypeId = 1,
                    Name = "ManagerMarketPlace"
                }
            );
        }
    }
}
