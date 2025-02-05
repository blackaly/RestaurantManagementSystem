using OrderingSystem.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace WebApplication11.Models.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        [Display(Name = "Role")]
        [EnumDataType(typeof(UsersTypes))]
        public ushort UserRole { get; set; }
        public string Email { get; set; }
        public string Address { get; set; } 

    }
}
