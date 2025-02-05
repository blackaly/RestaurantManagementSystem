using OrderingSystem.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderingSystem.Models.DbModels
{
    public class Reservations
    {
        public int Id { get; set; }
        [Required]
        public DateTime ReservationDate { get; set; }
        public DateTime EndTime {  get; set; }
        [Required]
        public int NumberOfPeople { get; set; }
        [Required]
        public string GuestName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public ReservationStatus ReservationStatus { get; set; }
        [Required]
        public string Email { get; set; }
        public int TableId { get; set; }
        [ForeignKey(nameof(TableId))]
        [Required]
        public Table Table { get; set; }

        

    }
}
