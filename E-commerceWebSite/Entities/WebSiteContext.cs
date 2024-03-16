using E_commerceWebSite.Models;
using Microsoft.EntityFrameworkCore;

namespace E_commerceWebSite.Entities
{
    public class WebSiteContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = DESKTOP-2C2PQI2 ; Database = WebSite ; Trusted_Connection = True ; TrustServerCertificate = True ; Encrypt = False");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
