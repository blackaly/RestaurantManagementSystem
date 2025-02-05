using OrderingSystem.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace OrderingSystem.Models.DbModels
{
    public class Staff
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName{ get; set; }
        public StaffRole Role { get; set; }
        public StaffShift Shift { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required]
        [RegularExpression(@"\^\\d{2}(0[1-9]|1[0-2])([0-2][1-9]|3[0-1])\\d{5}\\d{7}$\")]
        public string NationalId { get; set; }
        public string? AdditionalContactInfo { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
        public ICollection<Orders> Orders { get; set; }
    }
}
