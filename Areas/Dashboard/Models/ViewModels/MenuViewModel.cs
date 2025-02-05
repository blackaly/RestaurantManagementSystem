using System.ComponentModel.DataAnnotations;

namespace OrderingSystemDashboard.Models.ViewModels
{
    public class MenuViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
