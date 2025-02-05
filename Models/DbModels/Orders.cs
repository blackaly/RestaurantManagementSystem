using OrderingSystem.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderingSystem.Models.DbModels
{
    public class Orders
    {
        public int Id { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

    }
}
