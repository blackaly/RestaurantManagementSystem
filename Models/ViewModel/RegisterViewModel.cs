using System.ComponentModel.DataAnnotations;

namespace OrderingSystem.Models.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [MaxLength(100)]
        [RegularExpression(@"^[A-Za-z'-]{2,}(?: [A-Za-z'-]{2,})*$", ErrorMessage = "Name should not have numbers and must be greater than two")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        [RegularExpression(@"^[A-Za-z'-]{2,}(?: [A-Za-z'-]{2,})*$", ErrorMessage = "Name should not have numbers and must be greater than two")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public string? Address { get; set; } = "";
    }
}
