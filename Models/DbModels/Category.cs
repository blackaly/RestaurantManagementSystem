using System.ComponentModel.DataAnnotations;

namespace OrderingSystem.Models.DbModels
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string? ImageUrl { get; set; }
        public ICollection<MenuItems> MenuItems { get; set; }
    }
}
