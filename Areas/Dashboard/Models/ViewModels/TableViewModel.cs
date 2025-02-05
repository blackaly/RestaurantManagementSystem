using OrderingSystem.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace OrderingSystem.Areas.Dashboard.Models.ViewModels
{
    public class TableViewModel
    {
        [Required]
        [Display(Name = "Table Number")]
        public int TableNumber { get; set; }
        [Required]
        [Display(Name = "Seating Capacity")]
        public int SeatingCapacity { get; set; }
        public TableAvabilityStatus TableAvabilityStatus { get; set; }
    }
}
