using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderingSystem.Models.DbModels
{
    public class MenuItems
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int NumberOfAvailableItem { get; set; }
        [Required]
        public bool Availability { get; set; } = true;
        [Required]
        public string ImageUrl { get; set; }
        public int MenuId { get; set; }
        [ForeignKey(nameof(MenuId))]
        public Menu Menu { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
        public int? PromotionId { get; set; }
        [ForeignKey(nameof(PromotionId))]
        public Promotion? Promotion { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
        public ICollection<MenuItemPromotions> MenuItemPromotions { get; set; }
    }
}
