using Infrastructure.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts
{
    public class CoffeeCupContext : IdentityDbContext<AppUser>
    {
        public DbSet<CoffeeHouse> CoffeeHouses { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<CoffeeItem> CoffeeItems { get; set; }
        public CoffeeCupContext(DbContextOptions<CoffeeCupContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
