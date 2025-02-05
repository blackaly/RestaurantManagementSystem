using System.ComponentModel.DataAnnotations;

namespace WebApplication11.Models.ViewModel
{
    public class LoginViewModel
    {
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Rembmer me!")]
        public bool RememberMe { get; set; } = true;
    }
}
