using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderingSystem.Models.DbModels
{
    [PrimaryKey(nameof(MenuItemsId), nameof(PromotionId))]
    public class MenuItemPromotions
    {
        [ForeignKey(nameof(MenuItemsId))]
        public int MenuItemsId { get; set; }
        public MenuItems MenuItems { get; set; }
        public int PromotionId { get; set; }
        [ForeignKey(nameof(PromotionId))]
        public Promotion Promotion { get; set; }    
    }
}
