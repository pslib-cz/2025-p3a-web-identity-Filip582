using CoffeeRecordsIdentity.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeRecordsIdentity.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<CoffeeCup> Cups { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
