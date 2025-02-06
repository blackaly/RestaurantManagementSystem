using OrderingSystem.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace OrderingSystem.Areas.Dashboard.Models.ViewModels.Shared
{
    public class ReservationViewModel
    {
            
            public int id { get; set;}

            [Required]
            [Display(Name = "Reservation Date")]
            public string ReservationDate { get; set; }
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
            public int NumberOfTablesInSameDateTime { get; set; }
            public ReservationStatus ReservationStatus { get; set; }


        }

}
