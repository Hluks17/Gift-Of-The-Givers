using System.ComponentModel.DataAnnotations;

namespace GiftOfTheGivers.Models
{
    public class EmployeeLoginViewModel
    {
        [Required(ErrorMessage = "Please enter your employee email.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [Display(Name = "Employee Email")]
        public string Email { get; set; } = "";


        [Required(ErrorMessage = "Please enter your password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = "";


        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}