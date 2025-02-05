using OrderingSystemDashboard.Models.ViewModels.Shared;
using System.ComponentModel.DataAnnotations;

namespace OrderingSystemDashboard.Models.ViewModels
{
    public class MenuItemsViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Display(Name = "Is Available?")]
        public bool Availability { get; set; }
        [Display(Name = "Number of Avaliable Item")]
        [Required]
        public int  NumberofAvaliableItem { get; set; }
        [Display(Name = "Image")]
        public IFormFile? ImageUrl { get; set; }
        [Display(Name = "In What Menu?")]
        [Required]
        public int MenuId { get; set; }
        [Display(Name = "In What Category?")]
        [Required]
        public int CategoryId { get; set; }
    }
}
