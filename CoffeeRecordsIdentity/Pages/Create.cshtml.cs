using CoffeeRecordsIdentity.Data;
using CoffeeRecordsIdentity.InputModels;
using CoffeeRecordsIdentity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoffeeRecordsIdentity.Pages
{
    public class CreateModel(ILogger<CreateModel> logger, CoffeeRecordsIdentityContext context) : PageModel
    {
        private readonly ILogger<CreateModel> _logger = logger;
        private readonly CoffeeRecordsIdentityContext _context = context;

        [BindProperty]
        public CoffeeCupIM Input { get; set; } = new();

        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            _logger.LogInformation("OnPostAsync called with MachineNo: {MachineNo} and UserName: {UserName}", Input.MachineNo, Input.UserName);
            if (!ModelState.IsValid)
            {
                return Page();
            }
            CoffeeCup cc = new CoffeeCup { MachineNo = Input.MachineNo, UserName = Input.UserName, Created = DateTime.Now };
            _context.Cups.Add(cc);
            await _context.SaveChangesAsync();
            _logger.LogInformation("CoffeeCup created with Id: {CoffeeCupId}", cc.CoffeeCupId);

            return RedirectToPage("./Index");
        }
    }
}
