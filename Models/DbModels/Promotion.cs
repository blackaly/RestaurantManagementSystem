using System.ComponentModel.DataAnnotations.Schema;

namespace OrderingSystem.Models.DbModels
{
    public class Promotion
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Discountpercentage { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; }
        public bool ActiveStatus { get; set; } = true;
        public int MenuItemsId { get; set; }
        [ForeignKey(nameof(MenuItemsId))]
        public ICollection<MenuItems>? MenuItems { get; set; }
        public ICollection<MenuItemPromotions> MenuItemPromotions { get; set; } // If this promotion affects menu items
        public ICollection<Orders> Orders { get; set; } // If this promotion affects orders
    }
}
