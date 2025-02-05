using OrderingSystem.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderingSystem.Models.DbModels
{
    public class Feedback
    {
        public int Id { get; set; }
        [Required]
        public ushort Rating { get; set; }
        [Required]
        public RatingStatus RatingStatus { get; set; }
        public string? Comment { get; set; }
        public DateTime SubmittedAt {  get; set; } = DateTime.Now;
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        public int OrderId { get; set; }
        [ForeignKey(nameof(OrderId))]
        public Orders Orders { get; set; }


    }
}
