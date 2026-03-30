using CoffeeRecordsIdentity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CoffeeRecordsIdentity.Models;

namespace CoffeeRecordsIdentity.Data;

public class CoffeeRecordsIdentityContext : IdentityDbContext<ApplicationUser>
{
    public CoffeeRecordsIdentityContext(DbContextOptions<CoffeeRecordsIdentityContext> options)
        : base(options)
    {
    }
    public DbSet<CoffeeCup> Cups { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
