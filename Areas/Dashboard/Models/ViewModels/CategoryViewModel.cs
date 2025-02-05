using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace OrderingSystemDashboard.Models.ViewModels
{
    public class CategoryViewModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Display(Name = "Image")]
        public IFormFile ImageUrl { get; set; }
        // I Initialize it to be ignored by ModelState
        public string imageUrl { get; set; } = string.Empty;

    }
}
