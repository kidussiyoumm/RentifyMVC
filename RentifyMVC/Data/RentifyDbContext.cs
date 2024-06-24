using Microsoft.EntityFrameworkCore;
using Rentify.Models.Domains;
using System.Security.Cryptography.X509Certificates;


namespace RentifyMVC.Data

{
    public class RentifyDbContext : DbContext
    {
        public RentifyDbContext(DbContextOptions<RentifyDbContext> options) : base(options) //Pass it to DbContext class
        { 
            
        }

        public DbSet<Agent> Agents { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<RentalApplication> RentalApplications { get; set; }
        public DbSet<Review> Reviews { get; set; }
     

    }
}
