using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace CoffeeRecordsIdentity.Models;

public class ApplicationUser : IdentityUser
{
    public string Name { get; set; } = string.Empty;
}
