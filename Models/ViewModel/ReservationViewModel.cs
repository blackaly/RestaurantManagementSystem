using OrderingSystem.Models.DbModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderingSystem.Models.ViewModel
{
    public class ReservationViewModel
    {

        [Required]
        [Display(Name = "Reservation Date")]
        public DateOnly ReservationDate { get; set; }
        [Required]
        [Display(Name = "Time")]
        public string ReservationTime { get; set; }
        [Required]
        [Display(Name = "Number of People")]
        public int NumberOfPeople { get; set; }
        [Required]
        [Display(Name = "Guest Name")]
        public string GuestName { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Special Requests (Optional)")]
        public string? Comment { get; set; }
    }
}
