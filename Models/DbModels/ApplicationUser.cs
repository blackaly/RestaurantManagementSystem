using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace OrderingSystem.Models.DbModels
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        public ICollection<Orders>? Orders { get; set; }
        public ICollection<Reservations>? Reservations { get; set; }
        public ICollection<Feedback>? Feedbacks { get; set; }
    }
}
