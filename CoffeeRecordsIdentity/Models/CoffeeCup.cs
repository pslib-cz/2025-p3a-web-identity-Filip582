using System.ComponentModel.DataAnnotations;

namespace CoffeeRecordsIdentity.Models
{
    public class CoffeeCup
    {
        public int CoffeeCupId { get; set; }
        [Display(Name = "Short Name")]
        public string UserName { get; set; } = String.Empty;
        public string UserId { get; set; } = string.Empty;
        [Display(Name = "Time and date")]
        public DateTime Created { get; set; }
        [Display(Name = "Id of Machine")]
        public int MachineNo { get; set; }
        [Required]
        public ApplicationUser User { get; set; } = null!;

    }
}
