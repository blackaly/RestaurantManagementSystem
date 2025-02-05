using System.ComponentModel.DataAnnotations;

namespace OrderingSystem.Areas.Dashboard.Models.ViewModels
{
    public class RoleViewModel
    {
        [Required]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }
}
