using System.ComponentModel.DataAnnotations;

namespace OrderingSystem.Models.DbModels
{
    public class Menu
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }
        public ICollection<MenuItems> MenuItems { get; set; }
    }
}
