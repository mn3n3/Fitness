using Fitness.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Fitness.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<PlaceOfBirth> PlaceOfBirths { get; set; }
        public DbSet<CustomerCompany> CustomerCompanies { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Source> Sources { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Visitor> Visitors { get; set; }




        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}