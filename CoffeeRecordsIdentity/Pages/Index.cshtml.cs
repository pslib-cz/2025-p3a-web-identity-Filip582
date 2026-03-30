using CoffeeRecordsIdentity.Data;
using CoffeeRecordsIdentity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CoffeeRecordsIdentity.Pages
{
    public class IndexModel(ApplicationDbContext context, ILogger<IndexModel> logger) : PageModel
    {
        private readonly ILogger<IndexModel> _logger = logger;

        private readonly ApplicationDbContext _context = context;

        public IList<CoffeeCup> CoffeeCup { get; set; } = [];

        public async Task OnGetAsync()
        {
            _logger.LogInformation("Index page accessed at {DT}", DateTime.UtcNow);
            CoffeeCup = await _context.Cups.OrderBy(cc => cc.Created).ToListAsync();
        }
    }
}
