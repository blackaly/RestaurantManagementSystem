using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderingSystem.Models.DbModels
{
    public class OrderDetails
    {
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; } = decimal.Zero;
        public int OrderId { get; set; }
        [ForeignKey(nameof(OrderId))]
        public Orders Orders { get; set; }
        public int MenuItemsId { get; set; }
        [ForeignKey(nameof(MenuItemsId))]
        public MenuItems MenuItems { get; set; }
        public int? PromotionId { get; set; }
        [ForeignKey(nameof(PromotionId))]
        public Promotion? Promotion { get; set; }
        public ICollection<Payments> Payments { get; set; }
        public Feedback Feedback { get; set; }
        public int StaffId { get; set; }
        [ForeignKey(nameof(StaffId))]
        public Staff Staff { get; set; }
    }
}
