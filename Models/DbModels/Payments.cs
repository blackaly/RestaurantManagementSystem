using OrderingSystem.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderingSystem.Models.DbModels
{
    public class Payments
    {
        public int Id { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public decimal Amount { get; set; }
        public PaymentMethod paymentMethod { get; set; }
        public PaymentCashFlowStatus paymentCashFlowStatus { get; set; } = PaymentCashFlowStatus.Pending;
        public int OrderId { get; set; }
        [ForeignKey(nameof(OrderId))]
        public Orders Orders { get; set; }
    }
}
