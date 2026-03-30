using System.ComponentModel.DataAnnotations;

namespace CoffeeRecordsIdentity.Models
{
    public class CoffeeCup
    {
        public int CoffeeCupId { get; set; }
        [Display(Name = "Short Name")]
        public string UserName { get; set; } = String.Empty;
        //public ApplicationUser UserId { get; set; } // asi?
        [Display(Name = "Time and date")]
        public DateTime Created { get; set; }
        [Display(Name = "Id of Machine")]
        public int MachineNo { get; set; }
    }
}
