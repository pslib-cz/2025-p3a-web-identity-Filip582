using System.ComponentModel.DataAnnotations;

namespace CoffeeRecordsIdentity.InputModels
{
    public class CoffeeCupIM
    {
        public int CoffeeCupId { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; } = string.Empty;
        [Display(Name = "Id of Machine")]
        public int MachineNo { get; set; }
    }
}
